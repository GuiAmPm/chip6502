using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip6502.Emulator.ChipOperations
{
    public static class InstructionMemoryAccessModeHelper
    {
        internal static Func<Chip, int> Implied(Action<Chip> instruction, int cycles)
        {
            return chip =>
            {
                instruction(chip);
                return cycles;
            };
        }

        internal static Func<Chip, int> Relative(Func<Chip, sbyte, bool> instruction, int cycles, int cyclesIfSuccess, int cycleIfSuccessToNewPage)
        {
            return chip =>
            {
                var oldPc = chip.State.PC;
                var success = instruction(chip, chip.NextPCSByte());

                if (success)
                    return oldPc >> 8 != chip.State.PC >> 8 ? cycleIfSuccessToNewPage : cyclesIfSuccess;

                return cycles;
            };
        }

        internal static Func<Chip, int> Accumulator(Action<Chip> instruction, int cycles)
        {
            return chip =>
            {
                instruction(chip);
                return cycles;
            };
        }

        internal static Func<Chip, int> Immediate(Action<Chip, byte> instruction, int cycles)
        {
            return chip =>
            {
                instruction(chip, chip.NextPCByte());
                return cycles;
            };
        }

        internal static Func<Chip, int> ZeroPage(Action<Chip, byte> instruction, int cycles)
        {
            return chip =>
            {
                instruction(chip, chip.Memory.ReadByte(chip.NextPCByte(), ChipMemory.Operation.Direct));
                return cycles;
            };
        }

        internal static Func<Chip, int> ZeroPagePointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                instruction(chip, chip.NextPCByte());
                return cycles;
            };
        }

        internal static Func<Chip, int> ZeroPageX(Action<Chip, byte> instruction, int cycles)
        {
            return chip =>
            {
                var nPtr = chip.NextPCByte() + chip.State.X;
                nPtr &= 0xFF;

                instruction(chip, chip.Memory.ReadByte(nPtr, ChipMemory.Operation.Direct));

                return cycles;
            };
        }

        internal static Func<Chip, int> ZeroPageXPointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var nPtr = chip.NextPCByte() + chip.State.X;
                if (nPtr >= 0x100) nPtr -= 0x100;

                instruction(chip, (ushort)nPtr);

                return cycles;
            };
        }

        internal static Func<Chip, int> ZeroPageY(Action<Chip, byte> instruction, int cycles)
        {
            return chip =>
            {
                var nPtr = chip.NextPCByte() + chip.State.Y;
                if (nPtr >= 0x100) nPtr -= 0x100;

                instruction(chip, chip.Memory.ReadByte(nPtr, ChipMemory.Operation.Direct));

                return cycles;
            };
        }

        internal static Func<Chip, int> ZeroPageYPointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var nPtr = chip.NextPCByte() + chip.State.Y;
                if (nPtr >= 0x100) nPtr -= 0x100;

                instruction(chip, (ushort)nPtr);

                return cycles;
            };
        }

        internal static Func<Chip, int> Absolute(Action<Chip, byte> instruction, int cycles)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                instruction(chip, chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct));
                return cycles;
            };
        }

        internal static Func<Chip, int> AbsolutePointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                instruction(chip, ptr);
                return cycles;
            };
        }

        internal static Func<Chip, int> AbsoluteX(Action<Chip, byte> instruction, int cycles, int cyclesIfCrossedPage)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                var nPtr = (ptr + chip.State.X);
                var crossedPage = ptr >> 8 != nPtr >> 8;

                instruction(chip, chip.Memory.ReadByte(nPtr, ChipMemory.Operation.Direct));

                if (crossedPage)
                    return cyclesIfCrossedPage;

                return cycles;
            };
        }

        internal static Func<Chip, int> AbsoluteXPointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                var nPtr = (ptr + chip.State.X);

                instruction(chip, (ushort)nPtr);

                return cycles;
            };
        }

        internal static Func<Chip, int> AbsoluteY(Action<Chip, byte> instruction, int cycles, int cyclesIfCrossedPage)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                var nPtr = (ptr + chip.State.Y);
                var crossedPage = ptr >> 8 != nPtr >> 8;

                instruction(chip, chip.Memory.ReadByte(nPtr, ChipMemory.Operation.Direct));

                if (crossedPage)
                    return cyclesIfCrossedPage;

                return cycles;
            };
        }

        internal static Func<Chip, int> AbsoluteYPointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                var nPtr = (ptr + chip.State.Y);

                instruction(chip, (ushort)nPtr);

                return cycles;
            };
        }

        internal static Func<Chip, int> Indirect(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var ptr = chip.NextPCUShort();
                var val = chip.Memory.ReadUShort(ptr, ChipMemory.Operation.Direct);
                instruction(chip, val);
                return cycles;
            };
        }

        internal static Func<Chip, int> IndirectX(Action<Chip, byte> instruction, int cycles)
        {
            return chip =>
            {
                ushort nPtr = GetIndirectXAddress(chip);
                var val = chip.Memory.ReadByte(nPtr, ChipMemory.Operation.Direct);

                instruction(chip, val);
                return cycles;
            };
        }

        internal static Func<Chip, int> IndirectXPointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                var nPtr = GetIndirectXAddress(chip);

                instruction(chip, nPtr);
                return cycles;
            };
        }

        internal static ushort GetIndirectXAddress(Chip chip)
        {
            var ptr = (chip.NextPCByte() + chip.State.X) & 0xff;
            var ptrH = (ptr + 1) & 0xff;

            var low = chip.Memory.ReadByte(ptr, ChipMemory.Operation.None);
            var high = chip.Memory.ReadByte(ptrH, ChipMemory.Operation.Direct);

            var nPtr = low + (high << 8);
            return (ushort)(nPtr & 0xffff);
        }


        internal static Func<Chip, int> IndirectY(Action<Chip, byte> instruction, int cycles, int cyclesIfCrossedPage)
        {
            return chip =>
            {
                ushort nPtr = GetIndirectYAddress(chip);
                var val = chip.Memory.ReadByte(nPtr, ChipMemory.Operation.Direct);

                instruction(chip, val);
                return cycles;
            };
        }

        internal static Func<Chip, int> IndirectYPointer(Action<Chip, ushort> instruction, int cycles)
        {
            return chip =>
            {
                ushort nPtr = GetIndirectYAddress(chip);

                instruction(chip, nPtr);
                return cycles;
            };
        }

        internal static ushort GetIndirectYAddress(Chip chip)
        {
            var ptr = chip.NextPCByte();
            var ptrH = (ptr + 1) & 0xff;

            var low = chip.Memory.ReadByte(ptr, ChipMemory.Operation.None);
            var high = chip.Memory.ReadByte(ptrH, ChipMemory.Operation.Direct);

            var nPtr = low + (high << 8) + chip.State.Y;
            return (ushort)(nPtr & 0xffff);
        }
    }
}

using Chip6502.Emulator.ChipOperations;
using System;

namespace Chip6502.Emulator
{
    public partial class Chip
    {
        public ChipState State { get; private set; }
        public ChipMemory Memory { get; private set; }

        public Chip(int instructionStartIndex, ChipMemory chipMemory = null)
        {
            State = new ChipState(instructionStartIndex);
            Memory = chipMemory ?? new ChipMemory();
        }

        public virtual void Run(int count = 0)
        {
            while ((count--) > 0)
            {
                Step();
            }
        }

        public virtual void Step()
        {
            var opcode = NextPCByte();

            if (!ChipInstructionMap.TryGetInstruction(opcode, out var instruction))
            {
                throw new InvalidOperationException($"Unsupported or Invalid Instruction. (0x{opcode:X2})");
            }

            var cycles = instruction(this);

            RegisterCycles(cycles);
        }

        public byte NextPCByte()
        {
            return Memory.ReadByte(State.PC++, ChipMemory.Operation.Program);
        }

        public sbyte NextPCSByte()
        {
            return Memory.ReadSByte(State.PC++, ChipMemory.Operation.Program);
        }

        public ushort NextPCUShort()
        {
            var value = Memory.ReadUShort(State.PC, ChipMemory.Operation.Program);

            State.PC += 2;
            return value;
        }

        private void RegisterCycles(int cycles)
        {
            State.EllapsedCycles += cycles;
            State.CycleBuffer += cycles;
        }

        public void PushByteToStack(byte b)
        {
            Memory.WriteByte(ChipState.STACK_ADDR_START + State.SP, b, ChipMemory.Operation.Stack);
            State.RegisterPush();
        }

        public byte PullByteFromStack()
        {
            State.RegisterPull();
            var val = Memory.ReadByte(ChipState.STACK_ADDR_START + State.SP, ChipMemory.Operation.Stack);

            return val;
        }

        public void PushUShortToStack(ushort b)
        {
            byte lo = (byte)(b & 0xFF),
                 hi = (byte)((b >> 8) & 0xFF);

            PushByteToStack(hi);
            PushByteToStack(lo);
        }

        public ushort PullUShortFromStack()
        {
            var lo = PullByteFromStack();
            var hi = PullByteFromStack() << 8;

            return (ushort)(lo + hi);
        }
    }
}

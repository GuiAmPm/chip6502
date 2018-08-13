using System.Runtime.InteropServices;
using System.Threading;

namespace Chip6502.Emulator
{
    public class ChipState
    {
        public const int MASK_CARRY_FLAG = 0b0000_0001,
                         MASK_ZERO_FLAG = 0b0000_0010,
                         MASK_INTERRUPT_DISABLE = 0b0000_0100,
                         MASK_DECIMAL_MODE = 0b0000_1000,
                         MASK_BREAK = 0b0001_0000,
                         MASK_RESERVED_BIT = 0b0010_0000,
                         MASK_OVERFLOW = 0b0100_0000,
                         MASK_NEGATIVE = 0b1000_0000;

        public const int STACK_ADDR_START = 0x0100,
                         STACK_ADDR_END = 0x01FF,
                         STACK_SIZE = STACK_ADDR_END - STACK_ADDR_START;

        private int flags = MASK_RESERVED_BIT | MASK_BREAK;
        private int sp = STACK_SIZE;

        // Flags
        public int Flags
        {
            get => flags;
            set
            {
                flags = value | MASK_RESERVED_BIT;
            }
        }

        public bool CFlag
        {
            get => (Flags & MASK_CARRY_FLAG) != 0;
            set
            {
                if (value) SetCFlag();
                else ClearCFlag();
            }
        }

        public bool ZFlag
        {
            get => (Flags & MASK_ZERO_FLAG) != 0;
            set
            {
                if (value) SetZFlag();
                else ClearZFlag();
            }
        }

        public bool IFlag
        {
            get => (Flags & MASK_INTERRUPT_DISABLE) != 0;
            set
            {
                if (value) SetIFlag();
                else ClearIFlag();
            }
        }

        public bool DFlag
        {
            get => (Flags & MASK_DECIMAL_MODE) != 0;
            set
            {
                if (value) SetDFlag();
                else ClearDFlag();
            }
        }

        public bool BFlag
        {
            get => (Flags & MASK_BREAK) != 0;
            set
            {
                if(value) SetBFlag();
                else ClearBFlag();

            }
        }

        public bool VFlag
        {
            get => (Flags & MASK_OVERFLOW) != 0;
            set
            {
                if(value) SetVFlag();
                else ClearVFlag();
            }
        }

        public bool NFlag
        {
            get => (Flags & MASK_NEGATIVE) != 0;
            set
            {
                if (value) SetNFlag();
                else ClearNFlag();
            }
        }

        // Registers
        public int A { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int PC { get; set; }

        public int SP 
        { 
            get => sp;
            set => sp = value & 0xFF;
        }

        public int EllapsedCycles { get; set; }

        public int CycleBuffer { get; set; }

        public ChipState(int instructionStartIndex)
        {
            PC = instructionStartIndex;
        }

        // Flag related methods

        public void SetCFlag() => Flags |= MASK_CARRY_FLAG;
        public void SetZFlag() => Flags |= MASK_ZERO_FLAG;
        public void SetIFlag() => Flags |= MASK_INTERRUPT_DISABLE;
        public void SetDFlag() => Flags |= MASK_DECIMAL_MODE;
        public void SetBFlag() => Flags |= MASK_BREAK;
        public void SetVFlag() => Flags |= MASK_OVERFLOW;
        public void SetNFlag() => Flags |= MASK_NEGATIVE;

        public void ClearCFlag() => Flags &= ~MASK_CARRY_FLAG;
        public void ClearZFlag() => Flags &= ~MASK_ZERO_FLAG;
        public void ClearIFlag() => Flags &= ~MASK_INTERRUPT_DISABLE;
        public void ClearDFlag() => Flags &= ~MASK_DECIMAL_MODE;
        public void ClearBFlag() => Flags &= ~MASK_BREAK;
        public void ClearVFlag() => Flags &= ~MASK_OVERFLOW;
        public void ClearNFlag() => Flags &= ~MASK_NEGATIVE;

        // STACK related methods

        public void RegisterPush()
        {
            SP = (SP - 1);
        }

        public void RegisterPull()
        {
            SP = (SP + 1);
        }

        public override string ToString()
        {
            return $"({A}, {X}, {Y}) {IntToBinaryString(Flags).PadLeft(8, '0')}";
        }
        private static string IntToBinaryString(int number)
        {
            const int mask = 1;
            var binary = string.Empty;
            while (number > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (number & mask) + binary;
                number = number >> 1;
            }

            return binary;
        }
    }
}

namespace Chip6502.Emulator.ChipOperations
{
    public static class ChipInstructionSet
    {
        public static void ADC(Chip chip, byte val)
        {
            int t = 0;
            int carry = (chip.State.CFlag ? 1 : 0);

            if (chip.State.DFlag)
            {
                var u = (chip.State.A & 0x0F) + (val & 0x0F) + carry;

                if (u > 0x09) { u += 0x06; }
                if (u >= 0x20) { u -= 0x10; }

                var d = (chip.State.A & 0xF0) + (val & 0xF0) + u;
                if ((d & 0xFF0) > 0x90) { d += 0x60; }

                t = d;
            }
            else { t = chip.State.A + val + carry; }


            chip.State.CFlag = t > 0xff;

            t &= 0xff;

            chip.State.VFlag = (~(chip.State.A ^ val) & (chip.State.A ^ t)).IsNegativeByte();
            chip.State.NFlag = t.IsNegativeByte();
            chip.State.ZFlag = t == 0;
            chip.State.A = t;
        }

        public static void ASL(Chip chip)
        {
            chip.State.A <<= 1;

            chip.State.CFlag = chip.State.A >= 0x100;

            if (chip.State.CFlag)
            {
                chip.State.A &= 0xFF;
            }

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void ASL(Chip chip, ushort ptr)
        {
            int m = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct) << 1;

            chip.State.CFlag = m >= 0x100;
            if (chip.State.CFlag)
            {
                m &= 0xFF;
            }

            chip.Memory.WriteByte(ptr, (byte)m, ChipMemory.Operation.Direct);

            chip.State.ZFlag = m == 0;
            chip.State.NFlag = m.IsNegativeByte();
        }

        public static void AND(Chip chip, byte val)
        {
            chip.State.A &= val;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static bool BCC(Chip chip, sbyte cur)
        {
            if (!chip.State.CFlag)
            {
                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static bool BCS(Chip chip, sbyte cur)
        {
            if (chip.State.CFlag)
            {
                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }
            return false;

        }

        public static bool BEQ(Chip chip, sbyte cur)
        {
            if (chip.State.ZFlag)
            {

                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static void BIT(Chip chip, ushort ptr)
        {
            var m = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct);
            var r = chip.State.A & m;

            chip.State.NFlag = (r & 0B1000_0000) != 0;
            chip.State.Flags = (chip.State.Flags & 0x3F) | (m & 0xC0);
            chip.State.ZFlag = r == 0;
        }

        public static bool BMI(Chip chip, sbyte cur)
        {
            if (chip.State.NFlag)
            {
                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static bool BNE(Chip chip, sbyte cur)
        {
            if (!chip.State.ZFlag)
            {

                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static bool BPL(Chip chip, sbyte cur)
        {
            if (!chip.State.NFlag)
            {
                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static void BRK(Chip chip)
        {
            chip.PushUShortToStack((ushort)(chip.State.PC + 1));
            chip.PushByteToStack((byte)(chip.State.Flags | ChipState.MASK_BREAK));

            chip.State.SetIFlag();

            chip.State.PC = chip.Memory.ReadUShort(0xFFFE, ChipMemory.Operation.Direct);
        }

        public static bool BVC(Chip chip, sbyte cur)
        {
            if (!chip.State.VFlag)
            {
                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static bool BVS(Chip chip, sbyte cur)
        {
            if (chip.State.VFlag)
            {
                var oldPc = chip.State.PC;
                chip.State.PC += cur;

                return true;
            }

            return false;
        }

        public static void CLC(Chip chip)
        {
            chip.State.ClearCFlag();
        }

        public static void CLD(Chip chip)
        {
            chip.State.ClearDFlag();
        }

        public static void CLI(Chip chip)
        {
            chip.State.ClearIFlag();
        }

        public static void CLV(Chip chip)
        {
            chip.State.ClearVFlag();
        }

        public static void CMP(Chip chip, byte val)
        {
            chip.State.CFlag = chip.State.A >= val;
            chip.State.ZFlag = chip.State.A == val;
            chip.State.NFlag = (chip.State.A - val).IsNegativeByte();
        }

        public static void CPX(Chip chip, byte val)
        {
            chip.State.CFlag = chip.State.X >= val;
            chip.State.ZFlag = chip.State.X == val;
            chip.State.NFlag = (chip.State.X - val).IsNegativeByte();
        }

        public static void CPY(Chip chip, byte val)
        {
            chip.State.CFlag = chip.State.Y >= val;
            chip.State.ZFlag = chip.State.Y == val;
            chip.State.NFlag = (chip.State.Y - val).IsNegativeByte();
        }

        public static void DEC(Chip chip, ushort ptr)
        {
            var m = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct) - 1;

            chip.State.ZFlag = m == 0;
            chip.State.NFlag = m.IsNegativeByte();

            chip.Memory.WriteByte(ptr, (byte)m, ChipMemory.Operation.Direct);
        }

        public static void DEX(Chip chip)
        {
            chip.State.X = (chip.State.X - 1) & 0xFF;

            chip.State.ZFlag = chip.State.X == 0;
            chip.State.NFlag = chip.State.X.IsNegativeByte();
        }

        public static void DEY(Chip chip)
        {
            chip.State.Y = (chip.State.Y - 1) & 0xFF;

            chip.State.ZFlag = chip.State.Y == 0;
            chip.State.NFlag = chip.State.Y.IsNegativeByte();
        }

        public static void EOR(Chip chip, byte val)
        {
            chip.State.A ^= val;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void INC(Chip chip, ushort ptr)
        {
            var m = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct) + 1;

            m &= 0xff;

            chip.State.ZFlag = m == 0;
            chip.State.NFlag = m.IsNegativeByte();

            chip.Memory.WriteByte(ptr, (byte)m, ChipMemory.Operation.Direct);
        }

        public static void INX(Chip chip)
        {
            chip.State.X = (chip.State.X + 1) & 0xff;

            chip.State.ZFlag = chip.State.X == 0;
            chip.State.NFlag = chip.State.X.IsNegativeByte();
        }

        public static void INY(Chip chip)
        {
            chip.State.Y = (chip.State.Y + 1) & 0xff;

            chip.State.ZFlag = chip.State.Y == 0;
            chip.State.NFlag = chip.State.Y.IsNegativeByte();
        }

        public static void JMP(Chip chip, ushort ptr)
        {
            chip.State.PC = ptr;
        }

        public static void JSR(Chip chip, ushort ptr)
        {
            chip.PushUShortToStack((ushort)(chip.State.PC - 1));
            chip.State.PC = ptr;
        }

        public static void LDA(Chip chip, byte val)
        {
            chip.State.A = val;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void LDX(Chip chip, byte val)
        {
            chip.State.X = val;

            chip.State.ZFlag = chip.State.X == 0;
            chip.State.NFlag = chip.State.X.IsNegativeByte();
        }

        public static void LDY(Chip chip, byte val)
        {
            chip.State.Y = val;

            chip.State.ZFlag = chip.State.Y == 0;
            chip.State.NFlag = chip.State.Y.IsNegativeByte();
        }

        public static void LSR(Chip chip)
        {
            var zeroBit = chip.State.A & 1;
            chip.State.A >>= 1;

            chip.State.CFlag = zeroBit == 1;
            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void LSR(Chip chip, ushort ptr)
        {
            var m = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct);
            var zeroBit = m & 1;
            m >>= 1;

            chip.Memory.WriteByte(ptr, m, ChipMemory.Operation.Direct);
            chip.State.CFlag = zeroBit == 1;
            chip.State.ZFlag = m == 0;
            chip.State.NFlag = m.IsNegativeByte();
        }

        public static void NOP(Chip chip)
        {

        }

        public static void PHA(Chip chip)
        {
            chip.PushByteToStack((byte)chip.State.A);
        }

        public static void PHP(Chip chip)
        {
            chip.PushByteToStack((byte)(chip.State.Flags | ChipState.MASK_BREAK));
        }

        public static void PLA(Chip chip)
        {
            chip.State.A = chip.PullByteFromStack();
            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void PLP(Chip chip)
        {
            chip.State.Flags = chip.PullByteFromStack();
        }

        public static void ROL(Chip chip)
        {
            chip.State.A <<= 1;

            if (chip.State.CFlag)
                chip.State.A |= 1;

            chip.State.CFlag = chip.State.A > 0x100;
            chip.State.A &= 0xff;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void ROL(Chip chip, ushort ptr)
        {
            var m = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct) << 1;

            if (chip.State.CFlag)
                m |= 1;

            chip.State.CFlag = m > 0x100;
            m &= 0xff;

            chip.Memory.WriteByte(ptr, (byte)m, ChipMemory.Operation.Direct);

            chip.State.ZFlag = m == 0;
            chip.State.NFlag = m.IsNegativeByte();
        }

        public static void ROR(Chip chip)
        {
            var val = chip.State.A;

            if (chip.State.CFlag)
                val |= 0x100;

            chip.State.CFlag = (val & 1) == 1;

            var m = (val >> 1) & 0xFF;

            chip.State.A = m;
            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void ROR(Chip chip, ushort ptr)
        {
            int val = chip.Memory.ReadByte(ptr, ChipMemory.Operation.Direct);

            if (chip.State.CFlag)
                val |= 0x100;

            chip.State.CFlag = (val & 1) == 1;

            var m = (val >> 1) & 0xFF;

            chip.Memory.WriteByte(ptr, (byte)m, ChipMemory.Operation.Direct);
            chip.State.ZFlag = m == 0;
            chip.State.NFlag = m.IsNegativeByte();
        }

        public static void RTI(Chip chip)
        {
            chip.State.Flags = chip.PullByteFromStack();
            chip.State.PC = chip.PullUShortFromStack();
        }

        public static void RTS(Chip chip)
        {
            int nPC = chip.PullUShortFromStack();
            chip.State.PC = nPC + 1;
        }

        public static void ORA(Chip chip, byte val)
        {
            chip.State.A |= val;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void SBC(Chip chip, byte val)
        {
            int t = 0;
            int carry = (chip.State.CFlag ? 0 : 1);

            t = chip.State.A - val - carry;

            chip.State.VFlag = ((chip.State.A ^ t) & 0x80) != 0
                               && ((chip.State.A ^ val) & 0x80) != 0;
            chip.State.CFlag = t > 0xff
                               || (chip.State.A >= ((val & 0xFF) + (carry)))
                               || (chip.State.A.IsNegativeByte()
                                   && (val + carry).IsPositiveByte()
                                   && t.IsPositiveByte());

            if (chip.State.DFlag)
            {
                var units = (chip.State.A & 0x0F) - (val & 0x0F) - carry;
                bool areUnitsNegative = units < 0x00;

                if (areUnitsNegative)
                {
                    if ((val + carry) > chip.State.A) { units += 0x9A; }
                    else { units -= 0x06; }
                }

                var tens = (chip.State.A & 0xF0) - (val & 0xF0) + units;

                if (!areUnitsNegative && tens < 0x00) { tens += 0xA0; }
                else { tens &= 0xff; }

                t = tens;
            }

            chip.State.NFlag = t.IsNegativeByte();

            chip.State.A = (t & 0xFF);
            chip.State.ZFlag = chip.State.A == 0;

        }

        public static void SEC(Chip chip)
        {
            chip.State.SetCFlag();
        }

        public static void SED(Chip chip)
        {
            chip.State.SetDFlag();
        }

        public static void SEI(Chip chip)
        {
            chip.State.SetIFlag();
        }

        public static void STA(Chip chip, ushort ptr)
        {
            chip.Memory.WriteByte(ptr, (byte)chip.State.A, ChipMemory.Operation.Direct);
        }

        public static void STX(Chip chip, ushort ptr)
        {
            chip.Memory.WriteByte(ptr, (byte)chip.State.X, ChipMemory.Operation.Direct);
        }
        public static void STY(Chip chip, ushort ptr)
        {
            chip.Memory.WriteByte(ptr, (byte)chip.State.Y, ChipMemory.Operation.Direct);
        }

        public static void TAX(Chip chip)
        {
            chip.State.X = chip.State.A;

            chip.State.ZFlag = chip.State.X == 0;
            chip.State.NFlag = chip.State.X.IsNegativeByte();
        }

        public static void TAY(Chip chip)
        {

            chip.State.Y = chip.State.A;

            chip.State.ZFlag = chip.State.Y == 0;
            chip.State.NFlag = chip.State.Y.IsNegativeByte();
        }

        public static void TSX(Chip chip)
        {
            chip.State.X = chip.State.SP;

            chip.State.ZFlag = chip.State.X == 0;
            chip.State.NFlag = chip.State.X.IsNegativeByte();
        }
        public static void TXA(Chip chip)
        {
            chip.State.A = chip.State.X;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }

        public static void TXS(Chip chip)
        {
            chip.State.SP = chip.State.X;
        }

        public static void TYA(Chip chip)
        {
            chip.State.A = chip.State.Y;

            chip.State.ZFlag = chip.State.A == 0;
            chip.State.NFlag = chip.State.A.IsNegativeByte();
        }
    }
}
using System;

namespace Chip6502.Emulator.ChipOperations
{
    using static InstructionMemoryAccessModeHelper;

    public static class ChipInstructionMap
    {
        private static readonly Func<Chip, int>[] instructions = new Func<Chip, int>[0xff];

        static ChipInstructionMap()
        {
            instructions[0x69] = Immediate(ChipInstructionSet.ADC, 2);
            instructions[0x65] = ZeroPage(ChipInstructionSet.ADC, 3);
            instructions[0x75] = ZeroPageX(ChipInstructionSet.ADC, 4);
            instructions[0x6D] = Absolute(ChipInstructionSet.ADC, 4);
            instructions[0x7D] = AbsoluteX(ChipInstructionSet.ADC, 4, 5);
            instructions[0x79] = AbsoluteY(ChipInstructionSet.ADC, 4, 5);
            instructions[0x61] = IndirectX(ChipInstructionSet.ADC, 6);
            instructions[0x71] = IndirectY(ChipInstructionSet.ADC, 5, 6);

            instructions[0x0A] = Accumulator(ChipInstructionSet.ASL, 2);
            instructions[0x06] = ZeroPagePointer(ChipInstructionSet.ASL, 5);
            instructions[0x16] = ZeroPageXPointer(ChipInstructionSet.ASL, 6);
            instructions[0x0E] = AbsolutePointer(ChipInstructionSet.ASL, 6);
            instructions[0x1E] = AbsoluteXPointer(ChipInstructionSet.ASL, 7);

            instructions[0x29] = Immediate(ChipInstructionSet.AND, 2);
            instructions[0x25] = ZeroPage(ChipInstructionSet.AND, 3);
            instructions[0x35] = ZeroPageX(ChipInstructionSet.AND, 4);
            instructions[0x2D] = Absolute(ChipInstructionSet.AND, 4);
            instructions[0x3D] = AbsoluteX(ChipInstructionSet.AND, 4, 5);
            instructions[0x39] = AbsoluteY(ChipInstructionSet.AND, 4, 5);
            instructions[0x21] = IndirectX(ChipInstructionSet.AND, 6);
            instructions[0x31] = IndirectY(ChipInstructionSet.AND, 5, 6);

            instructions[0x90] = Relative(ChipInstructionSet.BCC, 2, 3, 5);

            instructions[0xB0] = Relative(ChipInstructionSet.BCS, 2, 3, 5);

            instructions[0xF0] = Relative(ChipInstructionSet.BEQ, 2, 3, 5);

            instructions[0x24] = ZeroPagePointer(ChipInstructionSet.BIT, 3);
            instructions[0x2C] = AbsolutePointer(ChipInstructionSet.BIT, 4);

            instructions[0x30] = Relative(ChipInstructionSet.BMI, 2, 3, 5);

            instructions[0xD0] = Relative(ChipInstructionSet.BNE, 2, 3, 5);

            instructions[0x10] = Relative(ChipInstructionSet.BPL, 2, 3, 5);

            instructions[0x00] = Implied(ChipInstructionSet.BRK, 7);

            instructions[0x50] = Relative(ChipInstructionSet.BVC, 2, 3, 5);

            instructions[0x70] = Relative(ChipInstructionSet.BVS, 2, 3, 5);

            instructions[0x18] = Implied(ChipInstructionSet.CLC, 2);

            instructions[0xD8] = Implied(ChipInstructionSet.CLD, 2);

            instructions[0x58] = Implied(ChipInstructionSet.CLI, 2);

            instructions[0xB8] = Implied(ChipInstructionSet.CLV, 2);

            instructions[0xC9] = Immediate(ChipInstructionSet.CMP, 2);
            instructions[0xC5] = ZeroPage(ChipInstructionSet.CMP, 3);
            instructions[0xD5] = ZeroPageX(ChipInstructionSet.CMP, 4);
            instructions[0xCD] = Absolute(ChipInstructionSet.CMP, 4);
            instructions[0xDD] = AbsoluteX(ChipInstructionSet.CMP, 4, 5);
            instructions[0xD9] = AbsoluteY(ChipInstructionSet.CMP, 4, 5);
            instructions[0xC1] = IndirectX(ChipInstructionSet.CMP, 6);
            instructions[0xD1] = IndirectY(ChipInstructionSet.CMP, 5, 6);

            instructions[0xE0] = Immediate(ChipInstructionSet.CPX, 2);
            instructions[0xE4] = ZeroPage(ChipInstructionSet.CPX, 3);
            instructions[0xEC] = Absolute(ChipInstructionSet.CPX, 4);

            instructions[0xC0] = Immediate(ChipInstructionSet.CPY, 2);
            instructions[0xC4] = ZeroPage(ChipInstructionSet.CPY, 3);
            instructions[0xCC] = Absolute(ChipInstructionSet.CPY, 4);

            instructions[0xC6] = ZeroPagePointer(ChipInstructionSet.DEC, 5);
            instructions[0xD6] = ZeroPageXPointer(ChipInstructionSet.DEC, 6);
            instructions[0xCE] = AbsolutePointer(ChipInstructionSet.DEC, 6);
            instructions[0xDE] = AbsoluteXPointer(ChipInstructionSet.DEC, 7);

            instructions[0xCA] = Implied(ChipInstructionSet.DEX, 2);

            instructions[0x88] = Implied(ChipInstructionSet.DEY, 2);

            instructions[0x49] = Immediate(ChipInstructionSet.EOR, 2);
            instructions[0x45] = ZeroPage(ChipInstructionSet.EOR, 3);
            instructions[0x55] = ZeroPageX(ChipInstructionSet.EOR, 4);
            instructions[0x4D] = Absolute(ChipInstructionSet.EOR, 4);
            instructions[0x5D] = AbsoluteX(ChipInstructionSet.EOR, 4, 5);
            instructions[0x59] = AbsoluteY(ChipInstructionSet.EOR, 4, 5);
            instructions[0x41] = IndirectX(ChipInstructionSet.EOR, 6);
            instructions[0x51] = IndirectY(ChipInstructionSet.EOR, 5, 6);

            instructions[0xE6] = ZeroPagePointer(ChipInstructionSet.INC, 5);
            instructions[0xF6] = ZeroPageXPointer(ChipInstructionSet.INC, 6);
            instructions[0xEE] = AbsolutePointer(ChipInstructionSet.INC, 6);
            instructions[0xFE] = AbsoluteXPointer(ChipInstructionSet.INC, 7);

            instructions[0xE8] = Implied(ChipInstructionSet.INX, 2);

            instructions[0xC8] = Implied(ChipInstructionSet.INY, 2);

            instructions[0x4C] = AbsolutePointer(ChipInstructionSet.JMP, 3);
            instructions[0x6C] = Indirect(ChipInstructionSet.JMP, 5);

            instructions[0x20] = AbsolutePointer(ChipInstructionSet.JSR, 6);

            instructions[0xA9] = Immediate(ChipInstructionSet.LDA, 2);
            instructions[0xA5] = ZeroPage(ChipInstructionSet.LDA, 3);
            instructions[0xB5] = ZeroPageX(ChipInstructionSet.LDA, 4);
            instructions[0xAD] = Absolute(ChipInstructionSet.LDA, 4);
            instructions[0xBD] = AbsoluteX(ChipInstructionSet.LDA, 4, 5);
            instructions[0xB9] = AbsoluteY(ChipInstructionSet.LDA, 4, 5);
            instructions[0xA1] = IndirectX(ChipInstructionSet.LDA, 6);
            instructions[0xB1] = IndirectY(ChipInstructionSet.LDA, 5, 6);

            instructions[0xA2] = Immediate(ChipInstructionSet.LDX, 2);
            instructions[0xA6] = ZeroPage(ChipInstructionSet.LDX, 3);
            instructions[0xB6] = ZeroPageY(ChipInstructionSet.LDX, 4);
            instructions[0xAE] = Absolute(ChipInstructionSet.LDX, 4);
            instructions[0xBE] = AbsoluteY(ChipInstructionSet.LDX, 4, 5);

            instructions[0xA0] = Immediate(ChipInstructionSet.LDY, 2);
            instructions[0xA4] = ZeroPage(ChipInstructionSet.LDY, 3);
            instructions[0xB4] = ZeroPageX(ChipInstructionSet.LDY, 4);
            instructions[0xAC] = Absolute(ChipInstructionSet.LDY, 4);
            instructions[0xBC] = AbsoluteX(ChipInstructionSet.LDY, 4, 5);

            instructions[0x4A] = Accumulator(ChipInstructionSet.LSR, 2);
            instructions[0x46] = ZeroPagePointer(ChipInstructionSet.LSR, 5);
            instructions[0x56] = ZeroPageXPointer(ChipInstructionSet.LSR, 6);
            instructions[0x4E] = AbsolutePointer(ChipInstructionSet.LSR, 6);
            instructions[0x5E] = AbsoluteXPointer(ChipInstructionSet.LSR, 7);

            instructions[0xEA] = Implied(ChipInstructionSet.NOP, 2);

            instructions[0x48] = Implied(ChipInstructionSet.PHA, 3);

            instructions[0x08] = Implied(ChipInstructionSet.PHP, 3);

            instructions[0x68] = Implied(ChipInstructionSet.PLA, 4);

            instructions[0x28] = Implied(ChipInstructionSet.PLP, 4);

            instructions[0x2A] = Accumulator(ChipInstructionSet.ROL, 2);
            instructions[0x26] = ZeroPagePointer(ChipInstructionSet.ROL, 5);
            instructions[0x36] = ZeroPageXPointer(ChipInstructionSet.ROL, 6);
            instructions[0x2E] = AbsolutePointer(ChipInstructionSet.ROL, 6);
            instructions[0x3E] = AbsoluteXPointer(ChipInstructionSet.ROL, 7);

            instructions[0x6A] = Accumulator(ChipInstructionSet.ROR, 2);
            instructions[0x66] = ZeroPagePointer(ChipInstructionSet.ROR, 5);
            instructions[0x76] = ZeroPageXPointer(ChipInstructionSet.ROR, 6);
            instructions[0x6E] = AbsolutePointer(ChipInstructionSet.ROR, 6);
            instructions[0x7E] = AbsoluteXPointer(ChipInstructionSet.ROR, 7);

            instructions[0x40] = Implied(ChipInstructionSet.RTI, 6);

            instructions[0x09] = Immediate(ChipInstructionSet.ORA, 2);
            instructions[0x05] = ZeroPage(ChipInstructionSet.ORA, 3);
            instructions[0x15] = ZeroPageX(ChipInstructionSet.ORA, 4);
            instructions[0x0D] = Absolute(ChipInstructionSet.ORA, 4);
            instructions[0x1D] = AbsoluteX(ChipInstructionSet.ORA, 4, 5);
            instructions[0x19] = AbsoluteY(ChipInstructionSet.ORA, 4, 5);
            instructions[0x01] = IndirectX(ChipInstructionSet.ORA, 6);
            instructions[0x11] = IndirectY(ChipInstructionSet.ORA, 5, 6);

            instructions[0x60] = Implied(ChipInstructionSet.RTS, 6);

            instructions[0xE9] = Immediate(ChipInstructionSet.SBC, 2);
            instructions[0xE5] = ZeroPage(ChipInstructionSet.SBC, 3);
            instructions[0xF5] = ZeroPageX(ChipInstructionSet.SBC, 4);
            instructions[0xED] = Absolute(ChipInstructionSet.SBC, 4);
            instructions[0xFD] = AbsoluteX(ChipInstructionSet.SBC, 4, 5);
            instructions[0xF9] = AbsoluteY(ChipInstructionSet.SBC, 4, 5);
            instructions[0xE1] = IndirectX(ChipInstructionSet.SBC, 6);
            instructions[0xF1] = IndirectY(ChipInstructionSet.SBC, 5, 6);

            instructions[0x38] = Implied(ChipInstructionSet.SEC, 2);

            instructions[0xF8] = Implied(ChipInstructionSet.SED, 2);

            instructions[0x78] = Implied(ChipInstructionSet.SEI, 2);

            instructions[0x85] = ZeroPagePointer(ChipInstructionSet.STA, 3);
            instructions[0x95] = ZeroPageXPointer(ChipInstructionSet.STA, 4);
            instructions[0x8D] = AbsolutePointer(ChipInstructionSet.STA, 4);
            instructions[0x9D] = AbsoluteXPointer(ChipInstructionSet.STA, 5);
            instructions[0x99] = AbsoluteYPointer(ChipInstructionSet.STA, 5);
            instructions[0x81] = IndirectXPointer(ChipInstructionSet.STA, 6);
            instructions[0x91] = IndirectYPointer(ChipInstructionSet.STA, 6);

            instructions[0x86] = ZeroPagePointer(ChipInstructionSet.STX, 3);
            instructions[0x96] = ZeroPageYPointer(ChipInstructionSet.STX, 4);
            instructions[0x8E] = AbsolutePointer(ChipInstructionSet.STX, 4);

            instructions[0x84] = ZeroPagePointer(ChipInstructionSet.STY, 3);
            instructions[0x94] = ZeroPageXPointer(ChipInstructionSet.STY, 4);
            instructions[0x8C] = AbsolutePointer(ChipInstructionSet.STY, 4);

            instructions[0xAA] = Implied(ChipInstructionSet.TAX, 2);

            instructions[0xA8] = Implied(ChipInstructionSet.TAY, 2);

            instructions[0xBA] = Implied(ChipInstructionSet.TSX, 2);

            instructions[0x8A] = Implied(ChipInstructionSet.TXA, 2);

            instructions[0x9A] = Implied(ChipInstructionSet.TXS, 2);

            instructions[0x98] = Implied(ChipInstructionSet.TYA, 2);
        }

        public static bool TryGetInstruction(int opcode, out Func<Chip, int> instruction)
        {
            if(opcode < 0 || opcode > instructions.Length)
            {
                instruction = null;
                return false;
            }

            instruction = instructions[opcode];
            return instruction != null;
        }
    }
}

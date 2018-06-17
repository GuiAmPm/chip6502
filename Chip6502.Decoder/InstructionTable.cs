using System.Collections.Generic;

namespace Chip6502.Decoder
{
    //Lazy<Me> :)
    using IAM = InstructionAddressingMode;

    public static class InstructionTable
    {

        private const string FORMAT_IMPLIED = "",
                             FORMAT_ACCUMULATOR = " A",
                             FORMAT_IMMEDIATE = " #{0:X2}",
                             FORMAT_ZERO_PAGE = " ${0:X2}",
                             FORMAT_ZERO_PAGE_X = FORMAT_ZERO_PAGE + ", X",
                             FORMAT_ZERO_PAGE_Y = FORMAT_ZERO_PAGE + ", Y",
                             FORMAT_RELATIVE = "*{0:X2}",
                             FORMAT_ABSOLUTE = " ${1:X2}{0:X2}",
                             FORMAT_ABSOLUTE_X = FORMAT_ABSOLUTE + ", X",
                             FORMAT_ABSOLUTE_Y = FORMAT_ABSOLUTE + ", Y",
                             FORMAT_INDIRECT = " (${1:X2}{0:X2})",
                             FORMAT_INDIRECT_X = " (${0:X2}, X)",
                             FORMAT_INDIRECT_Y = " (${0:X2}), Y";

        public static Dictionary<int, (string Name, IAM Addressing)> Instructions
        { get; } = new Dictionary<int, (string Name, IAM Addressing)>
        {
            // ADC
            { 0x69, ("ADC", IAM.Immediate) },
            { 0x65, ("ADC", IAM.ZeroPage) },
            { 0x75, ("ADC", IAM.ZeroPageX) },
            { 0x6D, ("ADC", IAM.Absolute) },
            { 0x7D, ("ADC", IAM.AbsoluteX) },
            { 0x79, ("ADC", IAM.AbsoluteY) },
            { 0x61, ("ADC", IAM.IndirectX) },
            { 0x71, ("ADC", IAM.IndirectY) },

            // AND
            { 0x29, ("AND", IAM.Immediate) },
            { 0x25, ("AND", IAM.ZeroPage) },
            { 0x35, ("AND", IAM.ZeroPageX) },
            { 0x2D, ("AND", IAM.Absolute) },
            { 0x3D, ("AND", IAM.AbsoluteX) },
            { 0x39, ("AND", IAM.AbsoluteY) },
            { 0x21, ("AND", IAM.IndirectX) },
            { 0x31, ("AND", IAM.IndirectY) },

            // ASL
            { 0x0A, ("ASL", IAM.Accumulator) },
            { 0x06, ("ASL", IAM.ZeroPage) },
            { 0x16, ("ASL", IAM.ZeroPageX) },
            { 0x0E, ("ASL", IAM.Absolute) },
            { 0x1E, ("ASL", IAM.AbsoluteX) },

            // BCC
            { 0x90, ("BCC", IAM.Relative) },

            // BCS
            { 0xB0, ("BCS", IAM.Relative) },

            // BEQ
            { 0xF0, ("BEQ", IAM.Relative) },

            // BIT
            { 0x24, ("BIT", IAM.ZeroPage) },
            { 0x2C, ("BIT", IAM.Absolute) },

            // BMI
            { 0x30, ("BMI", IAM.Relative) },

            // BNE
            { 0xD0, ("BNE", IAM.Relative) },

            // BPL
            { 0x10, ("BPL", IAM.Relative) },

            // BRK
            { 0x00, ("BRK", IAM.Implied) },

            // BVC
            { 0x50, ("BVC", IAM.Relative) },

            // BVS
            { 0x70, ("BVS", IAM.Relative) },

            // CLC
            { 0x18, ("CLC", IAM.Implied) },

            // CLD
            { 0xD8, ("CLD", IAM.Implied) },

            // CLI
            { 0x58, ("CLI", IAM.Implied) },

            // CLV
            { 0xB8, ("CLV", IAM.Implied) },

            // CMP
            { 0xC9, ("CMP", IAM.Immediate) },
            { 0xC5, ("CMP", IAM.ZeroPage) },
            { 0xD5, ("CMP", IAM.ZeroPageX) },
            { 0xCD, ("CMP", IAM.Absolute) },
            { 0xDD, ("CMP", IAM.AbsoluteX) },
            { 0xD9, ("CMP", IAM.AbsoluteY) },
            { 0xC1, ("CMP", IAM.IndirectX) },
            { 0xD1, ("CMP", IAM.IndirectY) },

            // CPX
            { 0xE0, ("CPX", IAM.Immediate) },
            { 0xE4, ("CPX", IAM.ZeroPage) },
            { 0xEC, ("CPX", IAM.Absolute) },

            // CPY
            { 0xC0, ("CPY", IAM.Immediate) },
            { 0xC4, ("CPY", IAM.ZeroPage) },
            { 0xCC, ("CPY", IAM.Absolute) },

            // DEC
            { 0xC6, ("DEC", IAM.ZeroPage) },
            { 0xD6, ("DEC", IAM.ZeroPageX) },
            { 0xCE, ("DEC", IAM.Absolute) },
            { 0xDE, ("DEC", IAM.AbsoluteX) },

            // DEX
            { 0xCA, ("DEX", IAM.Implied) },

            // DEY
            { 0x88, ("DEY", IAM.Implied) },

            // EOR
            { 0x49, ("EOR", IAM.Immediate) },
            { 0x45, ("EOR", IAM.ZeroPage) },
            { 0x55, ("EOR", IAM.ZeroPageX) },
            { 0x4D, ("EOR", IAM.Absolute) },
            { 0x5D, ("EOR", IAM.AbsoluteX) },
            { 0x59, ("EOR", IAM.AbsoluteY) },
            { 0x41, ("EOR", IAM.IndirectX) },
            { 0x51, ("EOR", IAM.IndirectY) },

            // INC
            { 0xE6, ("INC", IAM.ZeroPage) },
            { 0xF6, ("INC", IAM.ZeroPageX) },
            { 0xEE, ("INC", IAM.Absolute) },
            { 0xFE, ("INC", IAM.AbsoluteX) },

            // INX
            { 0xE8, ("INX", IAM.Implied) },

            // INY
            { 0xC8, ("INY", IAM.Implied) },

            // JMP
            { 0x4C, ("JMP", IAM.Absolute) },
            { 0x6C, ("JMP", IAM.Indirect) },

            // JSR
            { 0x20, ("JSR", IAM.Absolute) },

            // LDA
            { 0xA9, ("LDA", IAM.Immediate) },
            { 0xA5, ("LDA", IAM.ZeroPage) },
            { 0xB5, ("LDA", IAM.ZeroPageX) },
            { 0xAD, ("LDA", IAM.Absolute) },
            { 0xBD, ("LDA", IAM.AbsoluteX) },
            { 0xB9, ("LDA", IAM.AbsoluteY) },
            { 0xA1, ("LDA", IAM.IndirectX) },
            { 0xB1, ("LDA", IAM.IndirectY) },

            // LDX
            { 0xA2, ("LDX", IAM.Immediate) },
            { 0xA6, ("LDX", IAM.ZeroPage) },
            { 0xB6, ("LDX", IAM.ZeroPageY) },
            { 0xAE, ("LDX", IAM.Absolute) },
            { 0xBE, ("LDX", IAM.AbsoluteY) },

            // LDY
            { 0xA0, ("LDY", IAM.Immediate) },
            { 0xA4, ("LDY", IAM.ZeroPage) },
            { 0xB4, ("LDY", IAM.ZeroPageX) },
            { 0xAC, ("LDY", IAM.Absolute) },
            { 0xBC, ("LDY", IAM.AbsoluteX) },

            // LSR
            { 0x4A, ("LSR", IAM.Accumulator) },
            { 0x46, ("LSR", IAM.ZeroPage) },
            { 0x56, ("LSR", IAM.ZeroPageX) },
            { 0x4E, ("LSR", IAM.Absolute) },
            { 0x5E, ("LSR", IAM.AbsoluteX) },

            // NOP
            { 0xEA, ("NOP", IAM.Implied) },

            // ORA
            { 0x09, ("ORA", IAM.Immediate) },
            { 0x05, ("ORA", IAM.ZeroPage) },
            { 0x15, ("ORA", IAM.ZeroPageX) },
            { 0x0D, ("ORA", IAM.Absolute) },
            { 0x1D, ("ORA", IAM.AbsoluteX) },
            { 0x19, ("ORA", IAM.AbsoluteY) },
            { 0x01, ("ORA", IAM.IndirectX) },
            { 0x11, ("ORA", IAM.IndirectY) },

            // PHA
            { 0x48, ("PHA", IAM.Implied) },

            // PHP
            { 0x08, ("PHP", IAM.Implied) },

            // PLA
            { 0x68, ("PLA", IAM.Implied) },

            // PLP
            { 0x28, ("PLP", IAM.Implied) },

            // ROL
            { 0x2A, ("ROL", IAM.Accumulator) },
            { 0x26, ("ROL", IAM.ZeroPage) },
            { 0x36, ("ROL", IAM.ZeroPageX) },
            { 0x2E, ("ROL", IAM.Absolute) },
            { 0x3E, ("ROL", IAM.AbsoluteX) },

            // ROR
            { 0x6A, ("ROR", IAM.Accumulator) },
            { 0x66, ("ROR", IAM.ZeroPage) },
            { 0x76, ("ROR", IAM.ZeroPageX) },
            { 0x6E, ("ROR", IAM.Absolute) },
            { 0x7E, ("ROR", IAM.AbsoluteX) },

            // RTI
            { 0x40, ("RTI", IAM.Implied) },

            // RTS
            { 0x60, ("RTS", IAM.Implied) },

            // SBC
            { 0xE9, ("SBC", IAM.Immediate) },
            { 0xE5, ("SBC", IAM.ZeroPage) },
            { 0xF5, ("SBC", IAM.ZeroPageX) },
            { 0xED, ("SBC", IAM.Absolute) },
            { 0xFD, ("SBC", IAM.AbsoluteX) },
            { 0xF9, ("SBC", IAM.AbsoluteY) },
            { 0xE1, ("SBC", IAM.IndirectX) },
            { 0xF1, ("SBC", IAM.IndirectY) },

            // SEC
            { 0x38, ("SEC", IAM.Implied) },

            // SED
            { 0xF8, ("SED", IAM.Implied) },

            // SEI
            { 0x78, ("SEI", IAM.Implied) },

            // STA
            { 0x85, ("STA", IAM.ZeroPage) },
            { 0x95, ("STA", IAM.ZeroPageX) },
            { 0x8D, ("STA", IAM.Absolute) },
            { 0x9D, ("STA", IAM.AbsoluteX) },
            { 0x99, ("STA", IAM.AbsoluteY) },
            { 0x81, ("STA", IAM.IndirectX) },
            { 0x91, ("STA", IAM.IndirectY) },

            // STX
            { 0x86, ("STX", IAM.ZeroPage) },
            { 0x96, ("STX", IAM.ZeroPageY) },
            { 0x8E, ("STX", IAM.Absolute) },

            // STY
            { 0x84, ("STX", IAM.ZeroPage) },
            { 0x94, ("STX", IAM.ZeroPageX) },
            { 0x8C, ("STX", IAM.Absolute) },

            // TAX
            { 0xAA, ("TAX", IAM.Implied) },

            // TAY
            { 0xA8, ("TAY", IAM.Implied) },

            // TSX
            { 0xBA, ("TSX", IAM.Implied) },

            // TXA
            { 0x8A, ("TXA", IAM.Implied) },

            // TXS
            { 0x9A, ("TXS", IAM.Implied) },

            // TYA
            { 0x98, ("TYA", IAM.Implied) },
        };

        public static int GetInstructionSize(IAM addressing)
        {
            switch(addressing)
            {
                case IAM.Absolute:
                case IAM.AbsoluteX:
                case IAM.AbsoluteY:
                case IAM.Indirect:
                    return 3;
                case IAM.Relative:
                case IAM.IndirectX:
                case IAM.IndirectY:
                case IAM.ZeroPage:
                case IAM.ZeroPageX:
                case IAM.ZeroPageY:
                case IAM.Immediate:
                    return 2;
                case IAM.Implied:
                case IAM.Accumulator:
                    return 1;
            }

            return 0;
        }

        public static string GetFormat(IAM addressing)
        {
            switch(addressing)
            {
                case IAM.Absolute: return FORMAT_ABSOLUTE;
                case IAM.AbsoluteX: return FORMAT_ABSOLUTE_X;
                case IAM.AbsoluteY: return FORMAT_ABSOLUTE_Y;
                case IAM.Accumulator: return FORMAT_ACCUMULATOR;
                case IAM.Immediate: return FORMAT_IMMEDIATE;
                case IAM.Implied: return FORMAT_IMPLIED;
                case IAM.Indirect: return FORMAT_INDIRECT;
                case IAM.IndirectX: return FORMAT_INDIRECT_X;
                case IAM.IndirectY: return FORMAT_INDIRECT_Y;
                case IAM.Relative: return FORMAT_RELATIVE;
                case IAM.ZeroPage: return FORMAT_ZERO_PAGE;
                case IAM.ZeroPageX: return FORMAT_ZERO_PAGE_X;
                case IAM.ZeroPageY: return FORMAT_ZERO_PAGE_Y;
                default: return string.Empty;
            }
        }
    }
}

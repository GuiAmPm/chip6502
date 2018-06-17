using Chip6502.Emulator;
using System.Collections.Generic;
using System.Text;

namespace Chip6502.Decoder
{
    public static class InstructionDecoding
    {
        public static List<string> DecodeNextOperations(Chip chip, int count)
        {
            List<string> result = new List<string>(count);

            int offset = 0;

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < count; i++)
            {
                var nextOpAddress = chip.State.PC + (offset++);

                if (nextOpAddress > 0xFFFF) { break; }

                var instruction = chip.Memory.ReadByte(nextOpAddress, ChipMemory.Operation.None);

                if(!InstructionTable.Instructions.TryGetValue(instruction, out var instructionInfo))
                {
                    instructionInfo = ("???", InstructionAddressingMode.Implied);
                }

                var (name, addressing) = instructionInfo;

                var size = InstructionTable.GetInstructionSize(addressing);
                var format = InstructionTable.GetFormat(addressing);

                sb.AppendFormat("{0:X4}", nextOpAddress);
                sb.Append(": ");
                sb.AppendFormat("{0:X2}", instruction);

                object[] param = new object[size-1];

                for(int x = 0; x < param.Length; x++)
                {
                    param[x] = chip.Memory.ReadByte(chip.State.PC + (offset++), ChipMemory.Operation.None);
                    sb.AppendFormat("{0:X2}", param[x]);
                }

                while(sb.Length < 13)
                {
                    sb.Append(" ");
                }

                sb.Append(name);
                sb.AppendFormat(format, param);
                result.Add(sb.ToString());

                sb.Clear();
            }

            return result;
        }
    }
}

using System;
using System.IO;
using System.Text;

namespace Chip6502.Emulator.Tests
{
    public static class TestSetup
    {
        private const string ASSETS_FOLDER = ".\\Assets\\";

        public static Chip Setup(int instructionStartIndex)
        {
            Chip chip = new Chip(instructionStartIndex);
            return chip;
        }

        public static void LoadAssetCode(Chip chip, string path, int startIndex, int? length = null)
        {
            string assetPath = Path.Combine(ASSETS_FOLDER, path);
            byte[] fileData = File.ReadAllBytes(assetPath);

            chip.Memory.Load(fileData, startIndex, length);
        }

        public static void TearDown(Chip chip)
        {

        }

        public static bool TestFlags(Chip chip, string flags)
        {
            foreach(var flag in flags)
            {
                switch(flag)
                {
                    case 'n': if (chip.State.NFlag) return false; break;
                    case 'v': if (chip.State.VFlag) return false; break;
                    case 'b': if (chip.State.BFlag) return false; break;
                    case 'd': if (chip.State.DFlag) return false; break;
                    case 'i': if (chip.State.IFlag) return false; break;
                    case 'z': if (chip.State.ZFlag) return false; break;
                    case 'c': if (chip.State.CFlag) return false; break;

                    case 'N': if (!chip.State.NFlag) return false; break;
                    case 'V': if (!chip.State.VFlag) return false; break;
                    case 'B': if (!chip.State.BFlag) return false; break;
                    case 'D': if (!chip.State.DFlag) return false; break;
                    case 'I': if (!chip.State.IFlag) return false; break;
                    case 'Z': if (!chip.State.ZFlag) return false; break;
                    case 'C': if (!chip.State.CFlag) return false; break;

                    case '-': continue;

                    default: return false;
                }
            }

            return true;
        }

        internal static object FormatFlags(Chip chip)
        {
            StringBuilder result = new StringBuilder(8);

            result.Append(chip.State.NFlag ? 'N' : 'n');
            result.Append(chip.State.VFlag ? 'V' : 'v');
            result.Append('-');
            result.Append(chip.State.DFlag ? 'D' : 'd');
            result.Append(chip.State.IFlag ? 'I' : 'i');
            result.Append(chip.State.ZFlag ? 'Z' : 'z');
            result.Append(chip.State.CFlag ? 'C' : 'c');

            return result.ToString();
        }
    }
}

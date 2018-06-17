using System;

namespace Chip6502.Emulator.ChipOperations
{
    static class InstructionHelper
    {
        internal static bool IsNegativeByte(this int value)
        {
            return (value & 0x80) != 0;
        }

        internal static bool IsNegativeByte(this byte value) => IsNegativeByte((int)value);

        internal static bool IsPositiveByte(this int value)
        {
            return (value & 0x80) == 0;
        }

        internal static bool IsPositiveByte(this byte value) => IsPositiveByte((int)value);

    }
}

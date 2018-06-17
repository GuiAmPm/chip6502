using System;
using System.IO;

namespace Chip6502.Emulator
{
    public class ChipMemory
    {
        [Flags]
        public enum Operation
        {
            None = 0,
            Read = 1,
            Write = 2,

            Program = 4,
            Stack = 8,
            Direct = 16
        }

        public const int MEMORY_SIZE = 0x10000;
        public const int MEMORY_ADDR_MASK = MEMORY_SIZE - 1;

        protected byte[] internalMemory;

        #region Debug Variables

        public int LastReadDirectAddress { get; private set; }

        public int LastWriteDirectAddress { get; private set; }

        public int LastReadStackAddress { get; private set; }

        public int LastWrittenStackAddress { get; private set; }

        public int LastReadProgramAddress { get; private set; }

        #endregion

        public ChipMemory()
        {
            internalMemory = new byte[MEMORY_SIZE];
        }

        public void Load(Stream stream, int startIndex)
        {
            stream.Read(internalMemory, startIndex, MEMORY_SIZE - startIndex);
        }

        public void Load(byte[] data, int startIndex, int? length = null)
        {
            length = length ?? data.Length;

            if (startIndex + length > internalMemory.Length)
            {
                throw new IndexOutOfRangeException("You are trying to load more data than the available memory.");
            }

            Array.Copy(data, 0, internalMemory, startIndex, length.Value);
        }

        public virtual byte ReadByte(int address, Operation op)
        {
            if (op != Operation.None) { RegisterAccess(address, op | Operation.Read); }

            return internalMemory[address & MEMORY_ADDR_MASK];
        }

        public virtual ushort ReadUShort(int address, Operation op)
        {
            if (op != Operation.None) { RegisterAccess(address, op | Operation.Read); }

            return (ushort)(internalMemory[address & MEMORY_ADDR_MASK]
                            + (internalMemory[(address + 1) & MEMORY_ADDR_MASK] << 8));
        }

        public virtual short ReadShort(int address, Operation op)
        {
            if (op != Operation.None) { RegisterAccess(address, op | Operation.Read); }

            return (short)(internalMemory[address & MEMORY_ADDR_MASK]
                           + (internalMemory[(address + 1) & MEMORY_ADDR_MASK] << 8));
        }

        internal sbyte ReadSByte(int address, Operation op)
        {
            if (op != Operation.None) { RegisterAccess(address, op | Operation.Read); }

            return unchecked((sbyte)internalMemory[address]);
        }

        public virtual void WriteByte(int address, byte val, Operation op)
        {
            if (op != Operation.None) { RegisterAccess(address, op | Operation.Write); }

            internalMemory[address] = val;
        }

        private void RegisterAccess(int address, Operation operation)
        {
            switch (operation)
            {
                case Operation.Program | Operation.Read:
                    LastReadProgramAddress = address;
                    break;
                case Operation.Stack | Operation.Read:
                    LastReadStackAddress = address;
                    break;
                case Operation.Stack | Operation.Write:
                    LastWrittenStackAddress = address;
                    break;
                case Operation.Direct | Operation.Read:
                    LastReadDirectAddress = address;
                    break;
                case Operation.Direct | Operation.Write:
                    LastWriteDirectAddress = address;
                    break;

                default:
                    throw new ArgumentException(nameof(operation), "Invalid memory operation.");
            }
        }
    }
}

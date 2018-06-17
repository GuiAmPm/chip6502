# C# MOS 6502 Emulator #

This is a simple MOS emulator I wrote in C# to power a Tamagotchi emulator I working on so it's made to be used as a library.

It's made for learning purposes and is not optimized in any way and do the minimum required to run 6502 assemblies.

This emulator is tested againts the Klaus2m5 functional tests found at:
 https://github.com/Klaus2m5/6502_65C02_functional_tests

This implementation uses a jump-table approach instead of a switch-case approach, every implementation of each instruction is stored on an array mapped by their opcode.

Features:
- All legal opcodes are implemented
- Decimal mode supported
- Interrupts are supported
- Jump-table approach
- Cycles for each instruction are registered

## Visualizer

The visualizer is a Windows.Forms executable application that exposes the registers and memory of the emulated processor, it supports loading 6502 compatible binaries and run them and is meant to monitor the status of the CPU during tests and is meant for debugging.

When a binary is loaded, the PC register is used as the starting point.

Features:
- Load 6502 supported binary
- Run or step the loaded binary
- Set one break point to each of the following:
    - PC register
    - Read memory address
    - Written memory address
- Override register values and flags
- Emulate CPU speed in Hz
- Decoded instruction history
- Current and future instructions (branching is are not considered)

## Known issues

- An expection is thrown whenever a invalid opcode is found
- Multi-threading in the Visualizer is not properly implemented
- Visualizer UI delay updates when a CPU speed is set
- While the library supports Linux and Mac, the Visualizer and unit tests can only be run on Windows
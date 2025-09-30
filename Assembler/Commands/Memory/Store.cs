using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory;

internal class Store : Command
{
    public override string Group => "Memory";
    public override string Name => "store";
    public override int Id => 12;

    public override int GetCommandType(string[] command)
    {
        if (command.Length == 0)
        {
            return 0;
        }
        else if (command.Length == 2)
        {
            return 1;
        }
        else if (command.Length == 1)
        {
            return 2;
        }
        else if (command.Length == 3)
        {
            return 3;
        }

        return -1;
    }

    public override int GetByteData(int commandType)
    {
        // 00: M   -> storage[H     << 8 | K]     | store
        // 01: M   -> storage[const << 8 | const] | store 0b00000000, 0b10000011
        // 10: reg -> storage[H     << 8 | K]     | store B
        // 11: reg -> storage[const << 8 | const] | store B, 0b00000000, 0b10000011

        switch (commandType)
        {
            case 0:
                {
                    return 0;
                }
            case 1:
                {
                    return 2;
                }
            case 2:
                {
                    return 1;
                }
            case 3:
                {
                    return 3;
                }
        }

        throw new InvalidCommandTypeException(Name, commandType);
    }

    public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
    {
        switch (commandType)
        {
            case 0:
                {
                    var index = (registers["H"] << 8) | registers["K"];
                    ram[index] = registers["M"];
                    break;
                }
            case 1:
                {
                    var index = (args[0] << 8) | args[1];
                    ram[index] = registers["M"];
                    break;
                }
            case 2:
                {
                    var index = (registers["H"] << 8) | registers["K"];
                    ram[index] = registers[args[0]];
                    break;
                }
            case 3:
                {
                    var index = (args[0] << 8) | args[1];
                    ram[index] = registers[args[0]];
                    break;
                }
        }

        pc += 2 + GetByteData(commandType);
    }
}
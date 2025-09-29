using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Logic;

internal class Or : Command
{
    public override string Group => "Logic";
    public override string Name => "or";
    public override int Id => 7;

    public override int GetCommandType(string[] command)
    {
        var registerCheck = new RegisterCheck();
        if (command.Length == 1)
        {
            if (registerCheck.Check(command[0]))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else if (command.Length == 2)
        {
            if (registerCheck.Check(command[1]))
            {
                return 3;
            }
            else
            {
                return 2;
            }
        }

        return -1;
    }

    public override int GetByteData(int commandType)
    {
        // 00: L   | const | or 5
        // 01: L   | reg   | or B
        // 10: reg | const | or B, 5
        // 11: reg | reg   | or B, C

        switch (commandType)
        {
            case 0:
            case 1:
                {
                    return 1;
                }
            case 2:
            case 3:
                {
                    return 2;
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
                    registers["L"] |= args[0];
                    break;
                }
            case 1:
                {
                    registers["L"] |= registers[args[0]];
                    break;
                }
            case 2:
                {
                    registers[args[0]] |= args[1];
                    break;
                }
            case 3:
                {
                    registers[args[0]] |= registers[args[1]];
                    break;
                }
        }

        pc += 2 + GetByteData(commandType);
    }
}
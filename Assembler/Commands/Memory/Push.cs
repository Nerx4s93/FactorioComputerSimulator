using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory;

internal class Push : Command
{
    public override string Group => "Memory";
    public override string Name => "push";
    public override int Id => 21;

    public override int GetCommandType(string[] command)
    {
        var registerCheck = new RegisterCheck();
        if (registerCheck.Check(command[0]))
        {
            return 1;
        }
        else if (command.Length == 2)
        {
            return 0;
        }

        return -1;
    }

    public override int GetByteData(int commandType)
    {
        // 00: const -> stek | push 9
        // 01: reg -> stek   | push A

        switch (commandType)
        {
            case 0:
            case 1:
                {
                    return 1;
                }
        }

        throw new InvalidCommandTypeException(Name, commandType);
    }

    public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
    {
        var stekAddr = (registers["Sba"] << 8) | registers["Sbb"];
        var addr = (registers["Spa"] << 8) | registers["Spb"];
        var sc = registers["Sc"];

        var direction = (sc & 0b1000_0000) != 0;
        var stackSize = sc & 0b0111_1111;

        if (Math.Abs(stekAddr - addr) + 1 > stackSize)
        {
            return;
        }

        switch (commandType)
        {
            case 0:
                {
                    ram[addr] = args[0];
                    break;
                }
            case 1:
                {
                    ram[addr] = registers[args[0]];
                    break;
                }
            default:
                {
                    return;
                }
        }

        addr += direction ? 1 : -1;

        registers["Spa"] = (byte)((addr >> 8) & 0xFF);
        registers["Spb"] = (byte)(addr & 0xFF);

        pc += 2 + GetByteData(commandType);
    }
}
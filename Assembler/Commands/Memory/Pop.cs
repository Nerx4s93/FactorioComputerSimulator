using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory;

internal class Pop : Command
{
    public override string Group => "Memory";
    public override string Name => "pop";
    public override int Id => 22;

    public override int GetCommandType(string[] command)
    {
        var registerCheck = new RegisterCheck();
        if (registerCheck.Check(command[0]))
        {
            return 0;
        }

        return -1;
    }

    public override int GetByteData(int commandType)
    {
        // 00: reg <- stek | pop A

        switch (commandType)
        {
            case 0:
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

        if (Math.Abs(stekAddr - addr) < 0)
        {
            return;
        }

        addr -= direction ? 1 : -1;
        var value = ram[addr];

        switch (commandType)
        {
            case 0:
                {
                    registers[args[0]] = value;
                    break;
                }
            default:
                {
                    return;
                }
        }

        registers["Spa"] = (byte)((addr >> 8) & 0xFF);
        registers["Spb"] = (byte)(addr & 0xFF);

        pc += 2 + GetByteData(commandType);
    }
}
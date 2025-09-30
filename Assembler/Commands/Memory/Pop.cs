using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory;

internal class Pop : Command
{
    public override string Group => "Memory";
    public override string Name => "pop";
    public override int Id => 21;

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
        pc += 2 + GetByteData(commandType);
    }
}
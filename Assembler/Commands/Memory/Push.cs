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
        pc += 2 + GetByteData(commandType);
    }
}
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions;

internal class Loop : Command
{
    public override string Group => "Transitions";
    public override string Name => "loop";
    public override int Id => 20;

    public override int GetCommandType(string[] command)
    {
        return 0;
    }

    public override int GetByteData(int commandType)
    {
        // 00: C - 1 & loop metka
        // metka указывает на адрес ячейки для перехода, занимает 2 байта

        return 2;
    }

    public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
    {
        int index = (args[0] << 8) | args[1];

        registers["C"] -= 1;

        if (registers["C"] != 0)
        {
            pc = index;
        }
        else
        {
            pc += 2 + GetByteData(commandType);
        }
    }
}
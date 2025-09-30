using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions;

internal class Ret : Command
{
    public override string Group => "Transitions";
    public override string Name => "ret";
    public override int Id => 24;

    public override int GetCommandType(string[] command)
    {
        return command.Length == 0 ? 0 : -1;
    }

    public override int GetByteData(int commandType)
    {
        switch (commandType)
        {
            case 0:
                {
                    return 0;
                }
        }

        throw new InvalidCommandTypeException(Name, commandType);
    }

    public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
    {
        var stekAddr = (registers["Cba"] << 8) | registers["Cbb"];
        var addr = (registers["Cpa"] << 8) | registers["Cpb"];
        var sc = registers["Cc"];

        var direction = (sc & 0b1000_0000) != 0 ? 1 : -1;
        var stackSize = sc & 0b0111_1111;

        if (Math.Abs(stekAddr - addr) == 0)
        {
            return;
        }

        addr -= direction * 2;

        var hi = ram[addr];
        var lo = ram[addr + direction];
        var returnAddr = hi << 8 | lo;

        registers["Cpa"] = (byte)((addr >> 8) & 0xFF);
        registers["Cpb"] = (byte)(addr & 0xFF);

        pc = returnAddr;
    }
}
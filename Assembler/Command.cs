using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler;

internal abstract class Command
{
    public abstract string Group { get; }
    public abstract string Name { get; }
    public abstract int Id { get; }

    public int GetCommandType(byte[] args)
    {
        string[] argStrings = args.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray();
        return GetCommandType(argStrings);
    }


    public abstract int GetCommandType(string[] command);
    public abstract int GetByteData(int commandType);
    public abstract void Execute(ref int pc, int commandType, byte[] args, Registers registers, Memory ram);
}
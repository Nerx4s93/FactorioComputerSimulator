using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler
{
    internal abstract class Command
    {
        public abstract string Group { get; }
        public abstract string Name { get; }
        public abstract int Id { get; }
        public abstract int ByteData { get; }

        public abstract void Execute(ref int pc, byte[] args, Registers registers, Memory ram);
    }
}
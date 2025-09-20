using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Inc : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "inc";
        public override int Id => 4;
        public override int ByteData => 1;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers[args[0]] += 1;
            pc += 2 + ByteData;
        }
    }
}

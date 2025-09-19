using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Div : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "div";
        public override int Id => 15;
        public override int ByteData => 1;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["A"] /= args[0];
            pc += 2 + ByteData;
        }
    }
}

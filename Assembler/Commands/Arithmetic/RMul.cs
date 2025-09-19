using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class RMul : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "rmul";
        public override int Id => 20;
        public override int ByteData => 1;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["A"] *= registers[args[0]];
            pc += 2 + ByteData;
        }
    }
}
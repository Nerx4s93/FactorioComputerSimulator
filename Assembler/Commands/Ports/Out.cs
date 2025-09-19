using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Ports
{
    internal class Out : Command
    {
        public override string Group => "Ports";
        public override string Name => "out";
        public override int Id => 101;
        public override int ByteData => 4;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            throw new System.NotImplementedException();
        }
    }
}

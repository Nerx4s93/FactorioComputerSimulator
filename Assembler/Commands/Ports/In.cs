using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Ports
{
    internal class In : Command
    {
        public override string Group => "Ports";
        public override string Name => "in";
        public override int Id => 100;
        public override int ByteData => 4;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            throw new System.NotImplementedException();
        }
    }
}

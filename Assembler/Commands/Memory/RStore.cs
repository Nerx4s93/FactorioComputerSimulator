using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class RStore : Command
    {
        public override string Group => "Memory";
        public override string Name => "rstore";
        public override int Id => 5;
        public override int ByteData => 0;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var index = (registers["D"] << 8) | registers["E"];
            ram[index] = registers["B"];
            pc += 2 + ByteData;
        }
    }
}
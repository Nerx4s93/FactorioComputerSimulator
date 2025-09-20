using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class Store : Command
    {
        public override string Group => "Memory";
        public override string Name => "store";
        public override int Id => 12;
        public override int ByteData => 2;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var index = (args[0] << 8) | args[1];
            ram[index] = registers["B"];
            pc += 2 + ByteData;
        }
    }
}

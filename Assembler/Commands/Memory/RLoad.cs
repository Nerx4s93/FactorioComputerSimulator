using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class RLoad : Command
    {
        public override string Group => "Memory";
        public override string Name => "rload";
        public override int Id => 4;
        public override int ByteData => 0;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var index = (registers["D"] << 8) | registers["E"];
            registers["B"] = ram[index];
            pc += 2 + ByteData;
        }
    }
}
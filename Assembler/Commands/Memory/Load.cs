using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class Load : Command
    {
        public override string Group => "Memory";
        public override string Name => "load";
        public override int Id => 11;
        public override int ByteData => 2;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var index = (args[0] << 8) | args[1];
            registers["B"] = ram[index];
            pc += 2 + ByteData;
        }
    }
}

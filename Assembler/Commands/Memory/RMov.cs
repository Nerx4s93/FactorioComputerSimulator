using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class RMov : Command
    {
        public override string Group => "Memory";
        public override string Name => "rmov";
        public override int Id => 3;
        public override int ByteData => 2;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers[args[0]] = registers[args[1]];
            pc += 2 + ByteData;
        }
    }
}
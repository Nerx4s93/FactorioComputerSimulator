using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Logic
{
    internal class RAnd : Command
    {
        public override string Group => "Logic";
        public override string Name => "rand";
        public override int Id => 10;
        public override int ByteData => 1;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["L"] &= registers[args[0]];
            pc += 2 + ByteData;
        }
    }
}
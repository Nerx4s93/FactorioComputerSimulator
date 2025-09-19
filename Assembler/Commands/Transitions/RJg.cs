using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class RJg : Command
    {
        public override string Group => "Transitions";
        public override string Name => "rjg";
        public override int Id => 29;
        public override int ByteData => 3;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            if (registers["J"] > registers[args[0]])
            {
                pc = (args[1] << 8) | args[2];
            }
            else
            {
                pc += 2 + ByteData;
            }
        }
    }
}
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jge : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jge";
        public override int Id => 18;
        public override int ByteData => 3;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            if (registers["J"] >= args[0])
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

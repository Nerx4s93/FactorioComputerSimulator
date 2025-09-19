using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jmp : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jmp";
        public override int Id => 27;
        public override int ByteData => 2;

        public override void Execute(ref int pc, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var jumpAddress = (args[0] << 8) | args[1];
            pc = jumpAddress;
        }
    }
}

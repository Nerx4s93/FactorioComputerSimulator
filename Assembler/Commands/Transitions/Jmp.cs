using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jmp : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jmp";
        public override int Id => 13;

        public override int GetByteData(int commandType)
        {
            return 2;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var jumpAddress = (args[0] << 8) | args[1];
            pc = jumpAddress;
        }
    }
}

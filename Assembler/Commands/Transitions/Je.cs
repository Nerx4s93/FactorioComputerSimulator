using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Je : Command
    {
        public override string Group => "Transitions";
        public override string Name => "je";
        public override int Id => 14;

        public override int GetByteData(int commandType)
        {
            return 3;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            if (registers["J"] == args[0])
            {
                pc = (args[1] << 8) | args[2];
            }
            else
            {
                pc += 2 + GetByteData(commandType);
            }
        }
    }
}

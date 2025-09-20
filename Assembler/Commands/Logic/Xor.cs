using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Logic
{
    internal class Xor : Command
    {
        public override string Group => "Logic";
        public override string Name => "xor";
        public override int Id => 8;

        public override int GetByteData(int commandType)
        {
            return 1;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["L"] ^= args[0];
            pc += 2 + GetByteData(commandType);
        }
    }
}

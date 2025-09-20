using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Dec : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "dec";
        public override int Id => 5;

        public override int GetByteData(int commandType)
        {
            return 1;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers[args[0]] -= 1;
            pc += 2 + GetByteData(commandType);
        }
    }
}

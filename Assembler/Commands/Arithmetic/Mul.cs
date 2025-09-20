using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Mul : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "mul";
        public override int Id => 2;

        public override int GetByteData(int commandType)
        {
            return 1;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["A"] *= args[0];
            pc += 2 + GetByteData(commandType);
        }
    }
}

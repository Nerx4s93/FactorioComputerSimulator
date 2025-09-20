using FactorioComputerSimulator.Assembler.Exceptions;
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
            // 00: A   * const | mul 5
            // 01: A   * reg   | mul B
            // 10: reg * const | mul B, 5
            // 11: reg * reg   | mul B, C

            switch (commandType)
            {
                case 0:
                case 1:
                    {
                        return 1;
                    }
                case 2:
                case 3:
                    {
                        return 2;
                    }
            }

            throw new InvalidCommandTypeException(Name, commandType);
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["A"] *= args[0];
            pc += 2 + GetByteData(commandType);
        }
    }
}

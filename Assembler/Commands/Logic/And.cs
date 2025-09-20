using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Logic
{
    internal class And : Command
    {
        public override string Group => "Logic";
        public override string Name => "and";
        public override int Id => 6;

        public override int GetByteData(int commandType)
        {
            // 00: L   & const | and 5
            // 01: L   & reg   | and B
            // 10: reg & const | and B, 5
            // 11: reg & reg   | and B, C

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
            registers["L"] &= args[0];
            pc += 2 + GetByteData(commandType);
        }
    }
}

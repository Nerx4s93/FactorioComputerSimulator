using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Add : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "add";
        public override int Id => 0;

        public override int GetByteData(int commandType)
        {
            // 00: A + const   | add 5
            // 01: A + reg     | add B
            // 10: reg + const | add B, 5
            // 11: reg + reg   | add B, C

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
            registers["A"] += args[0];
            pc += 2 + GetByteData(commandType);
        }
    }
}

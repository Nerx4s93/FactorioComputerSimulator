using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Dec : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "dec";
        public override int Id => 5;

        public override int GetCommandType(string[] command)
        {
            if (command.Length == 0)
            {
                return 0;
            }
            else if (command.Length == 1)
            {
                return 1;
            }

            return -1;
        }

        public override int GetByteData(int commandType)
        {
            // 00: A   - 1 | dec
            // 01: reg - 1 | deb B

            switch (commandType)
            {
                case 0:
                    {
                        return 0;
                    }
                case 1:
                    {
                        return 1;
                    }
            }

            throw new InvalidCommandTypeException(Name, commandType);
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers[args[0]] -= 1;
            pc += 2 + GetByteData(commandType);
        }
    }
}

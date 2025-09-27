using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class Mov : Command
    {
        public override string Group => "Memory";
        public override string Name => "mov";
        public override int Id => 10;

        public override int GetCommandType(string[] command)
        {
            var registerCheck = new RegisterCheck();
            if (command.Length == 2)
            {
                if (registerCheck.Check(command[1]))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return -1;
        }

        public override int GetByteData(int commandType)
        {
            // 00: reg <- const | mov B, 5
            // 01: reg <- reg   | mov B, C

            switch (commandType)
            {
                case 0:
                case 1:
                    {
                        return 2;
                    }
            }

            throw new InvalidCommandTypeException(Name, commandType);
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            switch (commandType)
            {
                case 0:
                    {
                        registers[args[0]] = args[1];
                        break;
                    }
                case 1:
                    {
                        registers[args[0]] = registers[args[1]];
                        break;
                    }
            }

            pc += 2 + GetByteData(commandType);
        }
    }
}

using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Logic
{
    internal class Not : Command
    {
        public override string Group => "Logic";
        public override string Name => "not";
        public override int Id => 9;

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
            // 00: ~L   | not
            // 01: ~reg | not B

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
            registers["L"] = (byte)~registers["L"];
            pc += 2 + GetByteData(commandType);
        }
    }
}

using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class Load : Command
    {
        public override string Group => "Memory";
        public override string Name => "load";
        public override int Id => 11;

        public override int GetByteData(int commandType)
        {
            // 00: M   <- H     << 8 | L     | load
            // 01: M   <- const << 8 | const | load 0b00000000, 0b10000011
            // 10: reg <- H     << 8 | L     | load B
            // 11: reg <- const << 8 | const | load B, 0b00000000, 0b10000011

            switch (commandType)
            {
                case 0:
                    {
                        return 0;
                    }
                case 1:
                    {
                        return 2;
                    }
                case 2:
                    {
                        return 1;
                    }
                case 3:
                    {
                        return 3;
                    }
            }

            throw new InvalidCommandTypeException(Name, commandType);
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var index = (args[0] << 8) | args[1];
            registers["B"] = ram[index];
            pc += 2 + GetByteData(commandType);
        }
    }
}

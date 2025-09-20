using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jl : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jl";
        public override int Id => 17;

        public override int GetByteData(int commandType)
        {
            // 00: J   < const | jl 5, metka
            // 01: J   < reg   | jl B, metka
            // 10: reg < const | jl B, 5, metka
            // 11: reg < reg   | jl B, C, metka
            // metka указывает на адрес ячейки для перехода, занимает 2 байта

            switch (commandType)
            {
                case 0:
                case 1:
                    {
                        return 3;
                    }
                case 2:
                case 3:
                    {
                        return 4;
                    }
            }

            throw new InvalidCommandTypeException(Name, commandType);
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            if (registers["J"] < args[0])
            {
                pc = (args[1] << 8) | args[2];
            }
            else
            {
                pc += 2 + GetByteData(commandType);
            }
        }
    }
}

using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jge : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jge";
        public override int Id => 18;

        public override int GetByteData(int commandType)
        {
            // 00: J   >= const | jge 5, metka
            // 01: J   >= reg   | jge B, metka
            // 10: reg >= const | jge B, 5, metka
            // 11: reg >= reg   | jge B, C, metka
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
            if (registers["J"] >= args[0])
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

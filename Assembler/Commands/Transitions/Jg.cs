using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jg : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jg";
        public override int Id => 16;

        public override int GetCommandType(string[] command)
        {
            var registerCheck = new RegisterCheck();
            if (command.Length == 2)
            {
                if (registerCheck.Check(command[0]))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (command.Length == 3)
            {
                if (registerCheck.Check(command[1]))
                {
                    return 3;
                }
                else
                {
                    return 2;
                }
            }

            return -1;
        }

        public override int GetByteData(int commandType)
        {
            // 00: J   > const | jg 5, metka
            // 01: J   > reg   | jg B, metka
            // 10: reg > const | jg B, 5, metka
            // 11: reg > reg   | jg B, C, metka
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
            if (registers["J"] > args[0])
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

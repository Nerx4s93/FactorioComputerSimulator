using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions
{
    internal class Jle : Command
    {
        public override string Group => "Transitions";
        public override string Name => "jle";
        public override int Id => 19;

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
            // 00: J   <= const | jle 5, metka
            // 01: J   <= reg   | jle B, metka
            // 10: reg <= const | jle B, 5, metka
            // 11: reg <= reg   | jle B, C, metka
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
            GetData(commandType, args, registers, out byte a, out byte b, out int index);

            if (a <= b)
            {
                pc = index;
            }
            else
            {
                pc += 2 + GetByteData(commandType);
            }
        }

        private void GetData(int commandType, byte[] args, Registers registers, out byte a, out byte b, out int index)
        {
            switch (commandType)
            {
                case 0:
                    {
                        a = registers["J"];
                        b = args[0];
                        index = (args[1] << 8) | args[2];
                        break;
                    }
                case 1:
                    {
                        a = registers["J"];
                        b = registers[args[0]];
                        index = (args[1] << 8) | args[2];
                        break;
                    }
                case 2:
                    {
                        a = registers[args[0]];
                        b = args[1];
                        index = (args[2] << 8) | args[3];
                        break;
                    }
                case 3:
                    {
                        a = registers[args[0]];
                        b = registers[args[1]];
                        index = (args[2] << 8) | args[3];
                        break;
                    }
                default:
                    {
                        a = 0;
                        b = 0;
                        index = 0;
                        return;
                    }
            }
        }
    }
}

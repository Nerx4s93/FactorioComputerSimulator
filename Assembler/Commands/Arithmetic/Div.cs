using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.ParsingChecks;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Arithmetic
{
    internal class Div : Command
    {
        public override string Group => "Arithmetic";
        public override string Name => "div";
        public override int Id => 3;

        public override int GetCommandType(string[] command)
        {
            var registerCheck = new RegisterCheck();
            if (command.Length == 1)
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
            else if (command.Length == 2)
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
            // 00: A   / const | div 5
            // 01: A   / reg   | div B
            // 10: reg / const | div B, 5
            // 11: reg / reg   | div B, C

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
            registers["A"] /= args[0];
            pc += 2 + GetByteData(commandType);
        }
    }
}

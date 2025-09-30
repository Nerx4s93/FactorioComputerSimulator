using FactorioComputerSimulator.Assembler.Exceptions;
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Transitions;

internal class Call : Command
{
    public override string Group => "Transitions";
    public override string Name => "call";
    public override int Id => 23;

    public override int GetCommandType(string[] command)
    {
        if (command.Length == 1)
        {
            return 0;
        }

        return -1;
    }

    public override int GetByteData(int commandType)
    {
        // 00: jmp metka && pc -> cstak | call function

        switch (commandType)
        {
            case 0:
                {
                    return 2;
                }
        }

        throw new InvalidCommandTypeException(Name, commandType);
    }

    public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
    {
        var stekAddr = (registers["Cba"] << 8) | registers["Cbb"];
        var addr = (registers["Cpa"] << 8) | registers["Cpb"];
        var sc = registers["Cc"];

        var direction = (sc & 0b1000_0000) != 0 ? 1 : -1;
        var stackSize = sc & 0b0111_1111;

        if (Math.Abs(stekAddr - addr) + 2 > stackSize)
        {
            return;
        }

        switch (commandType)
        {
            case 0:
                {
                    var returnAddr = pc + 2 + GetByteData(commandType);

                    ram[addr] = (byte)((returnAddr >> 8) & 0xFF);
                    ram[addr + 1] = (byte)(returnAddr & 0xFF);

                    addr += direction * 2;
                    registers["Cpa"] = (byte)((addr >> 8) & 0xFF);
                    registers["Cpb"] = (byte)(addr & 0xFF);

                    pc = (args[0] << 8) | args[1];

                    break;
                }
            default:
                {
                    return;
                }
        }
    }
}
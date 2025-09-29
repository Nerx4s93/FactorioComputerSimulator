namespace FactorioComputerSimulator.Assembler.Exceptions;

public class InvalidCommandTypeException : AsmException
{
    public string Command { get; }
    public int CommandType { get; }

    public InvalidCommandTypeException(string command, int commandType)
        : base($"Для команды '{command}' не существует типа {commandType}.")
    {
        Command = command;
        CommandType = commandType;
    }
}
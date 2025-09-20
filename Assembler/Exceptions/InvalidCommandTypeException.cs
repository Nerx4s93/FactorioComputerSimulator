namespace FactorioComputerSimulator.Assembler.Exceptions
{
    public class InvalidCommandTypeException : AsmException
    {
        public int CommandType { get; }

        public InvalidCommandTypeException(int commandType)
            : base($"Неизвестный тип команды: {commandType}. Допустимы значения 0–3.")
        {
            CommandType = commandType;
        }
    }

}

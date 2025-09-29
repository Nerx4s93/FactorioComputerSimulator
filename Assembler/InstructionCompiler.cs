using FactorioComputerSimulator.Assembler.ParsingChecks;

namespace FactorioComputerSimulator.Assembler;

internal class InstructionCompiler
{
    private readonly WordCheckManager _wordCheckManager = new WordCheckManager();

    public CompiledLine[] StartCompile(string[] code)
    {
        var cleanedLines = ClearCode(code);
        var labelToAddress = CollectLabelAddresses(cleanedLines);
        var binaryCode = ToBinaryFormat(cleanedLines, labelToAddress);
        ValidateBinaryCode(binaryCode);
        return binaryCode.ToArray();
    }

    private List<(int SourceIndex, string Line)> ClearCode(string[] code)
    {
        var result = new List<(int, string)>();

        for (var i = 0; i < code.Length; i++)
        {
            var line = code[i];
            var commentIndex = line.IndexOf("//");
            if (commentIndex != -1)
            {
                line = line.Substring(0, commentIndex);
            }

            line = line.Trim();
            if (!string.IsNullOrEmpty(line))
            {
                result.Add((i, line));
            }
        }

        return result;
    }

    private Dictionary<string, int> CollectLabelAddresses(List<(int SourceIndex, string Line)> code)
    {
        var labelToAddress = new Dictionary<string, int>();
        var byteOffset = 0;

        foreach (var pair in code)
        {
            var line = pair.Line;

            if (line.EndsWith(":"))
            {
                var label = line.Substring(0, line.Length - 1);
                labelToAddress[label] = byteOffset;
                continue;
            }

            var parts = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                continue;
            }

            var command = CommandRegistry.GetByName(parts[0]);
            if (command == null)
            {
                throw new Exception("Неизвестная команда: " + parts[0]);
            }

            var args = parts.Skip(1).ToArray();
            var commandType = command.GetCommandType(args);
            byteOffset += 2 + command.GetByteData(commandType);
        }

        return labelToAddress;
    }

    private List<CompiledLine> ToBinaryFormat(List<(int SourceIndex, string Line)> code, Dictionary<string, int> labelToAddress)
    {
        var result = new List<CompiledLine>();

        foreach (var pair in code)
        {
            var sourceIndex = pair.SourceIndex;
            var line = pair.Line;

            if (line.EndsWith(":"))
            {
                continue;
            }

            var parts = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                continue;
            }

            var commandName = parts[0];
            var command = CommandRegistry.GetByName(commandName);
            if (command == null)
            {
                throw new Exception("Неизвестная команда: " + commandName);
            }

            var binaryParts = new List<string>();

            // ID (8 бит)
            var id = (byte)command.Id;
            binaryParts.Add(Convert.ToString(id, 2).PadLeft(8, '0'));

            var args = parts.Skip(1).ToArray();

            // Тип команды (2 бита)
            var commandType = (byte)command.GetCommandType(args);
            var commandTypeString = Convert.ToString(commandType, 2).PadLeft(2, '0');

            // Количество байт аргументов (3 бита)
            var argCount = (byte)command.GetByteData(commandType);
            var argCountString = Convert.ToString(argCount, 2).PadLeft(3, '0');

            // Зарезервированные 3 бита
            binaryParts.Add(commandTypeString + argCountString + "000");


            for (var i = 1; i < parts.Length; i++)
            {
                var arg = parts[i];

                // Если аргумент — это метка, то заменяется её на адрес
                if (labelToAddress.TryGetValue(arg, out int addr))
                {
                    var high = (byte)((addr >> 8) & 0xFF);
                    var low = (byte)(addr & 0xFF);

                    binaryParts.Add(Convert.ToString(high, 2).PadLeft(8, '0'));
                    binaryParts.Add(Convert.ToString(low, 2).PadLeft(8, '0'));
                    continue;
                }

                // Если аргумент — регистр, прогоняем через проверки
                string replaced = null;
                foreach (var check in _wordCheckManager)
                {
                    var compiled = check.OnCompile(arg);
                    if (!string.IsNullOrEmpty(compiled))
                    {
                        replaced = compiled;
                        break;
                    }
                }

                binaryParts.Add(replaced ?? arg);
            }

            result.Add(new CompiledLine(sourceIndex, binaryParts.ToArray()));
        }

        return result;
    }

    private void ValidateBinaryCode(List<CompiledLine> binaryCode)
    {
        foreach (var line in binaryCode)
        {
            var parts = line.BinaryParts;
            if (parts.Length < 2)
            {
                continue;
            }

            foreach (var part in parts)
            {
                if (part.Length != 8 || !IsBinary(part))
                {
                    throw new Exception(
                        $"Ошибка: недопустимая бинарная строка '{part}'. Ожидалось 8 бит."
                    );
                }
            }

            // первый байт — ID команды
            var commandId = Convert.ToInt32(parts[0], 2);

            // второй байт — служебный: [2 бита тип][3 бита размер][3 бита резерв]
            var commandInfo = Convert.ToInt32(parts[1], 2);

            var commandType = (commandInfo >> 6) & 0b11;   // старшие 2 бита
            var expectedArgs = (commandInfo >> 3) & 0b111; // средние 3 бита
            var reserved = commandInfo & 0b111;            // младшие 3 бита

            if (reserved != 0)
            {
                throw new Exception(
                    $"Ошибка: зарезервированные биты в команде ID={commandId} должны быть равны 000."
                );
            }

            // проверка числа аргументов
            var actualArgs = parts.Length - 2;
            if (actualArgs != expectedArgs)
            {
                throw new Exception(
                    $"Ошибка: команда с ID={commandId} (тип={commandType}) ожидает {expectedArgs} аргументов, а получено {actualArgs}."
                );
            }
        }
    }

    private bool IsBinary(string str)
    {
        foreach (char c in str)
        {
            if (c != '0' && c != '1')
            {
                return false;
            }
        }

        return true;
    }
}
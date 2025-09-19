using System;
using System.Collections.Generic;

using FactorioComputerSimulator.Assembler.ParsingChecks;

namespace FactorioComputerSimulator.Assembler
{
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
                var trimmed = pair.Line.Trim();

                if (trimmed.EndsWith(":"))
                {
                    string label = trimmed.Substring(0, trimmed.Length - 1);
                    labelToAddress[label] = byteOffset;
                    continue;
                }

                var parts = trimmed.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                {
                    continue;
                }

                var command = CommandRegistry.GetByName(parts[0]);
                if (command == null)
                {
                    throw new Exception("Неизвестная команда: " + parts[0]);
                }

                byteOffset += 2 + command.ByteData;
            }

            return labelToAddress;
        }

        private List<CompiledLine> ToBinaryFormat(List<(int SourceIndex, string Line)> code, Dictionary<string, int> labelToAddress)
        {
            var result = new List<CompiledLine>();

            foreach (var pair in code)
            {
                var sourceIndex = pair.SourceIndex;
                var line = pair.Line.Trim();

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

                var id = (byte)command.Id;
                var argCount = (byte)command.ByteData;
                binaryParts.Add(Convert.ToString(id, 2).PadLeft(8, '0'));
                binaryParts.Add(Convert.ToString(argCount, 2).PadLeft(8, '0'));

                for (var i = 1; i < parts.Length; i++)
                {
                    var arg = parts[i];

                    if (labelToAddress.TryGetValue(arg, out int addr))
                    {
                        var high = (byte)((addr >> 8) & 0xFF);
                        var low = (byte)(addr & 0xFF);

                        binaryParts.Add(Convert.ToString(high, 2).PadLeft(8, '0'));
                        binaryParts.Add(Convert.ToString(low, 2).PadLeft(8, '0'));
                        continue;
                    }

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
                        throw new Exception("Ошибка: недопустимая бинарная строка '" + part + "'. Ожидалось 8 бит.");
                    }
                }

                var commandId = Convert.ToInt32(parts[0], 2);
                var expectedArgs = Convert.ToInt32(parts[1], 2);
                var actualArgs = parts.Length - 2;

                if (actualArgs != expectedArgs)
                {
                    throw new Exception("Ошибка: команда с ID=" + commandId + " ожидает " + expectedArgs + " аргументов, а получено " + actualArgs + ".");
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
}

namespace FactorioComputerSimulator.Assembler;

public record struct CompiledLine(int SourceLineIndex, string[] BbinaryParts);
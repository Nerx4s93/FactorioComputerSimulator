namespace FactorioComputerSimulator.Assembler;

public record struct CompiledLine(int SourceLineIndex, string[] BinaryParts)
{
    public override string ToString()
    {
        return string.Join(" ", BinaryParts);
    }
}
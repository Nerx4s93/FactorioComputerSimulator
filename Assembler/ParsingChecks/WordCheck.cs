namespace FactorioComputerSimulator.Assembler.ParsingChecks;

internal abstract class WordCheck
{
    public abstract bool Check(string word, out Color color);
    public abstract string OnCompile(string word);
}
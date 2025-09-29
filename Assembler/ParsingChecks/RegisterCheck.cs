using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.ParsingChecks;

internal class RegisterCheck : WordCheck
{
    private readonly Color _registerColor = Color.Cyan;

    public bool Check(string word)
    {
        return Registers.GetRegisterNames().Contains(word);
    }

    public override bool Check(string word, out Color color)
    {
        if (Registers.GetRegisterNames().Contains(word))
        {
            color = _registerColor;
            return true;
        }
        color = default;
        return false;
    }

    public override string OnCompile(string word)
    {
        if (Registers.GetRegisterNames().Contains(word))
        {
            var index = Registers.GetRegisterNames().ToList().IndexOf(word);
            var data = Convert.ToString(index, 2).PadLeft(8, '0');
            return $"{data}";
        }

        return "";
    }
}
namespace FactorioComputerSimulator.Assembler.ParsingChecks;

internal class CommandCheck : WordCheck
{
    private readonly Dictionary<string, Color> _groupColors = new Dictionary<string, Color>()
    {
        ["Arithmetic"] = Color.LightSalmon,
        ["Logic"] = Color.MediumPurple,
        ["Memory"] = Color.LightSkyBlue,
        ["Ports"] = Color.LightSeaGreen,
        ["Transitions"] = Color.Gold
    };

    public override bool Check(string word, out Color color)
    {
        var command = CommandRegistry.GetByName(word.ToLower());
        if (command != null && _groupColors.TryGetValue(command.Group, out color))
        {
            return true;
        }

        color = default;
        return false;
    }

    public override string OnCompile(string word)
    {
        return string.Empty;
    }
}
using System.Collections;
using System.Reflection;

namespace FactorioComputerSimulator.Assembler.ParsingChecks;

internal class WordCheckManager : IEnumerable<WordCheck>
{
    private readonly List<WordCheck> _checks;

    public WordCheckManager()
    {
        _checks = new List<WordCheck>();

        var baseType = typeof(WordCheck);
        var types = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && baseType.IsAssignableFrom(t));

        foreach (var type in types)
        {
            var instance = (WordCheck)Activator.CreateInstance(type)!;

            if (instance != null)
                _checks.Add(instance);
        }
    }

    public bool TryCheck(string word, out Color color)
    {
        foreach (var check in _checks)
        {
            if (check.Check(word, out color))
                return true;
        }
        color = default;
        return false;
    }

    public IEnumerator<WordCheck> GetEnumerator() => _checks.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
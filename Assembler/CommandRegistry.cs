using System.Reflection;

namespace FactorioComputerSimulator.Assembler;

internal static class CommandRegistry
{
    private static readonly Dictionary<int, Command> CommandsById = [];
    private static readonly Dictionary<string, Command> CommandsByName = [];

    static CommandRegistry()
    {
        var commandType = typeof(Command);
        var commandTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && commandType.IsAssignableFrom(t));

        foreach (var type in commandTypes)
        {
            if (Activator.CreateInstance(type) is Command command)
            {
                if (CommandsById.ContainsKey(command.Id))
                    throw new Exception($"Duplicate command ID: {command.Id}");

                if (CommandsByName.ContainsKey(command.Name))
                    throw new Exception($"Duplicate command name: {command.Name}");

                CommandsById[command.Id] = command;
                CommandsByName[command.Name] = command;
            }
        }
    }

    public static Command? GetById(int id)
    {
        return CommandsById.TryGetValue(id, out var cmd) ? cmd : null;
    }

    public static Command? GetByName(string name)
    {
        return CommandsByName.TryGetValue(name, out var cmd) ? cmd : null;
    }

    public static IEnumerable<Command> GetAll() => CommandsById.Values;
}
namespace FactorioComputerSimulator.Assembler.Simulation;

public class Registers
{
    private readonly Dictionary<string, byte> _registers = new Dictionary<string, byte>()
        {
            { "A", 0 }, // Арифметика
            { "L", 0 }, // Логика
            { "M", 0 }, // Память
            { "H", 0 }, // Старший байт памяти
            { "K", 0 }, // Младший байт памяти
            { "J", 0 }, // Сравнения
            { "C", 0 }, // Циклы
            { "B", 0 },
            { "D", 0 },
            { "E", 0 },
        };

    private static readonly string[] _registerNamesById = new string[]
        {
            "A", "L", "M", "H", "K", "J", "C", "B", "D", "E"
        };

    public byte this[string name]
    {
        get
        {
            if (!_registers.ContainsKey(name))
            {
                throw new ArgumentException($"Регистр '{name}' не существует.");
            }

            return _registers[name];
        }
        set
        {
            if (!_registers.ContainsKey(name))
            {
                throw new ArgumentException($"Регистр '{name}' не существует.");
            }

            _registers[name] = value;
            RegisterChanged?.Invoke(name, value);
        }
    }

    public byte this[int id]
    {
        get
        {
            if (id < 0 || id >= _registerNamesById.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Неверный ID регистра.");
            }

            var name = _registerNamesById[id];
            return this[name];
        }
        set
        {
            if (id < 0 || id >= _registerNamesById.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Неверный ID регистра.");
            }

            var name = _registerNamesById[id];
            this[name] = value;
        }
    }

    public static IEnumerable<string> GetRegisterNames()
    {
        return _registerNamesById;
    }

    public event Action<string, byte> RegisterChanged;
}
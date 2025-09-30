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
            { "S", 0 }, // Количество элементов в стеке
            { "Ss1", 0 }, // Старший байт, указывающий на начальный адрес стека
            { "Ss2", 0 }, // Младший байт, указывающий на начальный адрес стека
            { "Sc", 0 }, // Конфиг стека: 1 бит - направление стека, остальные - размер стека
            { "B0", 0 },
            { "B1", 0 },
            { "B2", 0 },
            { "B3", 0 },
            { "B4", 0 },
            { "B5", 0 },
            { "B6", 0 },
            { "B7", 0 },
        };

    private static readonly string[] _registerNamesById = new string[]
        {
            "A", "L", "M", "H", "K", "J", "C",
            "S", "Ss1", "Ss2", "Sc",
            "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7"
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
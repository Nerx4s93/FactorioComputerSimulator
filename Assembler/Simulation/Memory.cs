namespace FactorioComputerSimulator.Assembler.Simulation;

public class Memory
{
    private readonly byte[] _data;

    public int Size => _data.Length;
    public byte[] Raw => _data;

    public Memory(int size)
    {
        _data = new byte[size];
    }

    public byte this[int index]
    {
        get
        {
            if (index < 0 || index >= _data.Length)
            {
                throw new IndexOutOfRangeException($"Адрес {index} вне допустимого диапазона памяти.");
            }
            return _data[index];
        }
        set
        {
            if (index < 0 || index >= _data.Length)
            {
                throw new IndexOutOfRangeException($"Адрес {index} вне допустимого диапазона памяти.");
            }
            _data[index] = value;
            MemoryChanged?.Invoke(index, value);
        }
    }

    public event Action<int, byte> MemoryChanged;
}
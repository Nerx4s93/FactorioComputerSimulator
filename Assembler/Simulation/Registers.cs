using System;
using System.Collections.Generic;

namespace FactorioComputerSimulator.Assembler.Simulation
{
    public class Registers
    {
        private readonly Dictionary<string, byte> _registers = new Dictionary<string, byte>()
        {
            { "A", 0 },
            { "L", 0 },
            { "M", 0 },
            { "P", 0 },
            { "J", 0 },
            { "B", 0 },
            { "C", 0 },
            { "D", 0 },
            { "E", 0 },
        };

        private readonly string[] _registerNamesById = new string[]
        {
            "A", "L", "M", "P", "J", "B", "C", "D", "E"
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

        public IEnumerable<string> GetRegisterNames()
        {
            return _registers.Keys;
        }

        public event Action<string, byte> RegisterChanged;
    }
}
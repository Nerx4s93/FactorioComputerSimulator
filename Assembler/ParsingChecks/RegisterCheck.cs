using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FactorioComputerSimulator.Assembler.ParsingChecks
{
    internal class RegisterCheck : WordCheck
    {
        private static readonly HashSet<string> Registers = new HashSet<string>() { "A", "L", "M", "P", "J", "B", "C", "D", "E" };

        private readonly Color _registerColor = Color.Cyan;

        public bool Check(string word)
        {
            return Registers.Contains(word);
        }

        public override bool Check(string word, out Color color)
        {
            if (Registers.Contains(word))
            {
                color = _registerColor;
                return true;
            }
            color = default;
            return false;
        }

        public override string OnCompile(string word)
        {
            if (Registers.Contains(word))
            {
                var index = Registers.ToList().IndexOf(word);
                var data = Convert.ToString(index, 2).PadLeft(8, '0');
                return $"{data}";
            }

            return "";
        }
    }
}
using System;
using System.Drawing;

namespace FactorioComputerSimulator.Assembler.ParsingChecks
{
    internal class NumberCheck : WordCheck
    {
        private readonly Color _numberColor = Color.Orange;

        public override bool Check(string word, out Color color)
        {
            if (TryParseNumber(word, out _))
            {
                color = _numberColor;
                return true;
            }

            color = default;
            return false;
        }

        public override string OnCompile(string word)
        {
            if (TryParseNumber(word, out int value))
            {
                var data = Convert.ToString(value, 2).PadLeft(8, '0');
                return $"{data}";
            }

            return "";
        }

        private bool TryParseNumber(string s, out int value)
        {
            value = 0;
            if (string.IsNullOrEmpty(s))
                return false;

            s = s.ToLower();

            try
            {
                if (s.StartsWith("0b"))
                {
                    value = Convert.ToInt32(s.Substring(2), 2);
                    return true;
                }
                else if (s.StartsWith("0x"))
                {
                    value = Convert.ToInt32(s.Substring(2), 16);
                    return true;
                }
                else if (s.StartsWith("0o"))
                {
                    value = Convert.ToInt32(s.Substring(2), 8);
                    return true;
                }
                else
                {
                    return int.TryParse(s, out value);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
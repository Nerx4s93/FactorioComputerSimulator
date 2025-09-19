using System;
using System.Collections.Generic;
using System.Drawing;

namespace FactorioComputerSimulator.Assembler.ParsingChecks
{
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
            if (CommandRegistry.GetByName(word) is Command command)
            {
                var name = Convert.ToString(command.Id, 2).PadLeft(5, '0');
                var data = Convert.ToString(command.ByteData, 2).PadLeft(3, '0');

                return $"{name}{data}";
            }

            return "";
        }
    }
}
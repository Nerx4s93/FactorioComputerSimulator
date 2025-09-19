using System;
using System.Windows.Forms;
using FactorioComputerSimulator.GUI;

namespace FactorioComputerSimulator
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CodeEditor());
        }
    }
}

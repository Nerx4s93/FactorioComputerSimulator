using System;
using System.Windows.Forms;

using FactorioComputerSimulator.Assembler;
using FactorioComputerSimulator.Assembler.Simulation;
using FactorioComputerSimulator.GUI.Simulation;

namespace FactorioComputerSimulator.GUI
{
    public partial class SimulationForm : Form
    {
        private readonly SimulatorHandle _simulatorHandle;

        public SimulationForm(string[] code, SimulatorHandle simulatorHandle)
        {
            InitializeComponent();
            _simulatorHandle = simulatorHandle;
            richTextBox1.Lines = code;
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            SyntaxHighlighter.Highlight(richTextBox1);
            HighlightCurrentLine();
        }

        private void buttonRomShow_Click(object sender, EventArgs e) =>
            new MemoryInformationForm(this, _simulatorHandle.Rom).Show();

        private void buttonRamShow_Click(object sender, EventArgs e) =>
            new MemoryInformationForm(this, _simulatorHandle.Ram).Show();

        private void buttonRegistersShow_Click(object sender, EventArgs e) =>
            new RegistersInformationShow(this, _simulatorHandle.Registers).Show();

        private void ButtonStep_Click(object sender, EventArgs e)
        {
            _simulatorHandle.Step();
            LabelPCInfo.Text = $"PC={_simulatorHandle.PC}";

            HighlightCurrentLine();
        }

        private void HighlightCurrentLine()
        {
            var nextLineIndex = _simulatorHandle.GetNextSourceLineIndex();
            if (nextLineIndex == null || nextLineIndex >= richTextBox1.Lines.Length)
                return;

            var originalSelectionStart = richTextBox1.SelectionStart;
            var originalSelectionLength = richTextBox1.SelectionLength;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;

            var line = nextLineIndex.Value;
            var lineStart = richTextBox1.GetFirstCharIndexFromLine(line);
            var lineLength = richTextBox1.Lines[line].Length;

            richTextBox1.Select(lineStart, lineLength);
            richTextBox1.SelectionBackColor = System.Drawing.Color.Red;

            richTextBox1.Select(originalSelectionStart, originalSelectionLength);
        }
    }
}

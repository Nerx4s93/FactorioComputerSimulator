using System;
using System.Windows.Forms;

using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.GUI.Simulation
{
    public partial class MemoryInformationForm : Form
    {
        private readonly Memory _memory;
        private DisplayFormat _currentFormat = DisplayFormat.Hex;

        public MemoryInformationForm(Form parent, Memory memory)
        {
            InitializeComponent();
            parent.Closing += (sender, args) => Close();
            _memory = memory;
            _memory.MemoryChanged += Memory_MemoryChanged;
            LoadMemory(_memory);
        }

        private void Memory_MemoryChanged(int index, byte value)
        {
            if (MemoryGrid.InvokeRequired)
            {
                MemoryGrid.Invoke(new Action(() => Memory_MemoryChanged(index, value)));
                return;
            }

            if (index >= MemoryGrid.Rows.Count)
            {
                return;
            }

            var dataText = _currentFormat == DisplayFormat.Hex
                ? "0x" + value.ToString("X2")
                : Convert.ToString(value, 2).PadLeft(8, '0');

            MemoryGrid.Rows[index].Cells[1].Value = dataText;
        }


        private void ComboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFormat = ComboBoxFormat.SelectedItem.ToString() == "Hex"
                ? DisplayFormat.Hex
                : DisplayFormat.Bin;

            LoadMemory(_memory);
        }

        public void LoadMemory(Memory memory)
        {
            MemoryGrid.Rows.Clear();
            for (var i = 0; i < memory.Size; i++)
            {
                var index = _currentFormat == DisplayFormat.Hex
                    ? "0x" + i.ToString("X4")
                    : Convert.ToString(i, 2).PadLeft(16, '0');

                var data = _currentFormat == DisplayFormat.Hex
                    ? "0x" + memory[i].ToString("X2")
                    : Convert.ToString(memory[i], 2).PadLeft(8, '0');

                MemoryGrid.Rows.Add(index, data);
            }
        }
    }
}
using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.GUI.Simulation;

public partial class RegistersInformationShow : Form
{
    private readonly Registers _registers;
    private DisplayFormat _currentFormat = DisplayFormat.Hex;

    public RegistersInformationShow(Form parent, Registers registers)
    {
        InitializeComponent();
        parent.Closing += (sender, args) => Close();
        _registers = registers;
        _registers.RegisterChanged += Registers_RegisterChanged;
        LoadRegisterValues();
    }

    private void Registers_RegisterChanged(string name, byte value)
    {
        if (RegostersGrid.InvokeRequired)
        {
            RegostersGrid.Invoke(new Action(() => Registers_RegisterChanged(name, value)));
            return;
        }

        foreach (DataGridViewRow row in RegostersGrid.Rows)
        {
            if (row.Cells[0].Value?.ToString() == name)
            {
                var displayValue = _currentFormat == DisplayFormat.Hex
                    ? "0x" + value.ToString("X2")
                    : Convert.ToString(value, 2).PadLeft(8, '0');

                row.Cells[1].Value = displayValue;
                break;
            }
        }
    }

    private void LoadRegisterValues()
    {
        RegostersGrid.Rows.Clear();

        foreach (var name in _registers.GetRegisterNames())
        {
            var value = _registers[name];
            var displayValue = _currentFormat == DisplayFormat.Hex
                ? "0x" + value.ToString("X2")
                : Convert.ToString(value, 2).PadLeft(8, '0');

            RegostersGrid.Rows.Add(name, displayValue);
        }
    }

    private void ComboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentFormat = ComboBoxFormat.SelectedItem.ToString() == "Hex"
            ? DisplayFormat.Hex
            : DisplayFormat.Bin;

        LoadRegisterValues();
    }
}
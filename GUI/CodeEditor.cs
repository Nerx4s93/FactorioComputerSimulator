using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using FactorioComputerSimulator.Assembler;

namespace FactorioComputerSimulator.GUI
{
    public partial class CodeEditor : Form
    {
        private Core _core;

        private string _file;
        private bool _fileEdit;

        public CodeEditor()
        {
            InitializeComponent();
            _core = new Core(richTextBox1);
            richTextBox1.TextChanged += RichTextBox1OnTextChanged;

            richTextBox1.VScroll += (s, e) => lineNumbersBox.Invalidate();
            richTextBox1.Resize += (s, e) => lineNumbersBox.Invalidate();
            richTextBox1.MouseDown += (s, e) => lineNumbersBox.Invalidate();

            UpdateTop();
        }

        private void LineNumbersBox_Paint(object sender, PaintEventArgs e)
        {
            var font = richTextBox1.Font;
            var lineHeight = TextRenderer.MeasureText("0", font).Height;

            var firstVisibleIndex = richTextBox1.GetCharIndexFromPosition(new Point(0, 0));
            var firstLine = richTextBox1.GetLineFromCharIndex(firstVisibleIndex);
            var currentLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);

            var y = -richTextBox1.GetPositionFromCharIndex(firstVisibleIndex).Y;
            var visibleLines = richTextBox1.Height / lineHeight + 1;

            for (var i = 0; i < visibleLines; i++)
            {
                var lineNumber = firstLine + i;
                var posY = y + i * lineHeight;

                var brush = (lineNumber == currentLine)
                    ? Brushes.White
                    : new SolidBrush(Color.FromArgb(138, 138, 122));

                e.Graphics.DrawString((lineNumber + 1).ToString(), font, brush, new PointF(0, posY));

                if (brush is IDisposable dBrush && brush != Brushes.White)
                    dBrush.Dispose();
            }
        }

        #region  Файл

        private void RichTextBox1OnTextChanged(object sender, EventArgs e)
        {
            _fileEdit = true;
            lineNumbersBox.Invalidate();
            UpdateTop();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_file))
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Factorio Assembler files (*.fasm)|*.fasm|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "fasm";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    _file = saveFileDialog.FileName;
                }
                ;
            }

            File.WriteAllText(_file, richTextBox1.Text);
            _fileEdit = false;
            UpdateTop();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Factorio Assembler files (*.fasm)|*.fasm|All files (*.*)|*.*";
                openFileDialog.DefaultExt = "fasm";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _file = openFileDialog.FileName;
            }
            ;

            richTextBox1.Text = File.ReadAllText(_file);
            _fileEdit = false;
            UpdateTop();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateTop()
        {
            var end = _fileEdit ? "*" : "";
            Text = $"CodeEditor | {_file}{end}";
        }

        #endregion

        private void ButtonBuild_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _core.StartCompile();

                var form = new CompiledCodeForm(result);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка компиляции:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            var handle = _core.StartSimulation();
            var form = new SimulationForm(richTextBox1.Lines, handle);
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}

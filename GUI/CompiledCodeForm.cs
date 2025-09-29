using FactorioComputerSimulator.Assembler;

namespace FactorioComputerSimulator.GUI;

public partial class CompiledCodeForm : Form
{
    public CompiledCodeForm(CompiledLine[] code)
    {
        InitializeComponent();

        richTextBox1.VScroll += (s, e) => lineNumbersBox.Invalidate();
        richTextBox1.Resize += (s, e) => lineNumbersBox.Invalidate();
        richTextBox1.MouseDown += (s, e) => lineNumbersBox.Invalidate();

        var lines = new string[code.Length];
        for (var i = 0; i < code.Length; i++)
        {
            lines[i] = code[i].ToString();
        }
        richTextBox1.Lines = lines;

        Load += (s, e) => SyntaxHighlighter.Highlight(richTextBox1);
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
}
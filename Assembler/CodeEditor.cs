using Timer = System.Windows.Forms.Timer;

namespace FactorioComputerSimulator.Assembler;

internal class CodeEditor
{
    private readonly RichTextBox _richTextBox;
    private readonly Timer _highlightTimer;
    private bool _isHighlighting = false;

    public CodeEditor(RichTextBox richTextBox)
    {
        _richTextBox = richTextBox;

        _highlightTimer = new Timer { Interval = 200 };
        _highlightTimer.Tick += async (s, e) =>
        {
            _highlightTimer.Stop();
            await HighlightAsync();
        };

        _richTextBox.TextChanged += (s, e) =>
        {
            _highlightTimer.Stop();
            _highlightTimer.Start();
        };
    }

    private async Task HighlightAsync()
    {
        if (_isHighlighting)
        {
            return;
        }

        _isHighlighting = true;

        try
        {
            await Task.Run(() =>
            {
                _richTextBox.Invoke((Action)(() =>
                {
                    SyntaxHighlighter.Highlight(_richTextBox);
                }));
            });
        }
        finally
        {
            _isHighlighting = false;
        }
    }
}
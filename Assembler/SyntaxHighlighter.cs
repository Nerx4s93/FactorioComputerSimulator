using System.Runtime.InteropServices;

using FactorioComputerSimulator.Assembler.ParsingChecks;

namespace FactorioComputerSimulator.Assembler;

internal static class SyntaxHighlighter
{
    #region user32.dll

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    private const int WM_SETREDRAW = 0x0B;

    #endregion

    private static readonly Color CommentColor = Color.Gray;
    private static readonly WordCheckManager CheckManager = new WordCheckManager();

    public static void Highlight(RichTextBox box)
    {
        var text = box.Text;
        var lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
        var formatted = new List<(int index, int length, Color color)>();

        var globalIndex = 0;

        foreach (var line in lines)
        {
            var lineStart = globalIndex;

            if (line.Length == 0)
            {
                globalIndex += 1;
                continue;
            }

            var commentStart = line.IndexOf("//");
            var lineBeforeComment = line;

            if (commentStart != -1)
            {
                lineBeforeComment = line.Substring(0, commentStart);
                formatted.Add((lineStart + commentStart, line.Length - commentStart, CommentColor));
            }

            var parts = lineBeforeComment.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
            var currentPos = 0;

            foreach (var part in parts)
            {
                var wordIndex = lineBeforeComment.IndexOf(part, currentPos, StringComparison.Ordinal);
                if (wordIndex == -1)
                {
                    currentPos += part.Length;
                    continue;
                }

                var absoluteIndex = lineStart + wordIndex;

                if (CheckManager.TryCheck(part, out var color))
                {
                    formatted.Add((absoluteIndex, part.Length, color));
                }

                currentPos = wordIndex + part.Length;
            }

            globalIndex += line.Length + 1;
        }

        box.SuspendLayout();

        var handle = box.Handle;
        SendMessage(handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

        var selectionStart = box.SelectionStart;
        var selectionLength = box.SelectionLength;

        box.SelectAll();
        box.SelectionColor = box.ForeColor;
        box.SelectionBackColor = box.BackColor;

        foreach (var item in formatted)
        {
            box.Select(item.index, item.length);
            box.SelectionColor = item.color;
        }

        box.Select(selectionStart, selectionLength);
        SendMessage(handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
        box.Invalidate();
        box.ResumeLayout();
    }
}
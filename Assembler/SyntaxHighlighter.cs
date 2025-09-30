using System.Runtime.InteropServices;
using FactorioComputerSimulator.Assembler.ParsingChecks;

namespace FactorioComputerSimulator.Assembler;

internal static class SyntaxHighlighter
{
    #region WinAPI
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref Point lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    private const int WM_SETREDRAW = 0x0B;
    private const int EM_GETSCROLLPOS = 0x0400 + 221;
    private const int EM_SETSCROLLPOS = 0x0400 + 222;
    #endregion

    private static readonly Color CommentColor = Color.Gray;
    private static readonly WordCheckManager CheckManager = new WordCheckManager();

    public static void Highlight(RichTextBox box)
    {
        var selStart = box.SelectionStart;
        var selLength = box.SelectionLength;
        var scrollPos = new Point();
        SendMessage(box.Handle, EM_GETSCROLLPOS, IntPtr.Zero, ref scrollPos);

        SendMessage(box.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

        box.SelectAll();
        box.SelectionColor = box.ForeColor;
        box.SelectionBackColor = box.BackColor;

        var index = 0;
        foreach (var line in box.Text.Split('\n'))
        {
            var commentStart = line.IndexOf("//");
            if (commentStart != -1)
            {
                box.Select(index + commentStart, line.Length - commentStart);
                box.SelectionColor = CommentColor;
            }

            var codePart = commentStart >= 0 ? line[..commentStart] : line;
            var pos = 0;
            foreach (var part in codePart.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries))
            {
                var wordIndex = codePart.IndexOf(part, pos, StringComparison.Ordinal);
                if (wordIndex != -1 && CheckManager.TryCheck(part, out var color))
                {
                    box.Select(index + wordIndex, part.Length);
                    box.SelectionColor = color;
                }
                pos = wordIndex + part.Length;
            }

            index += line.Length + 1; // +1 для \n
        }

        box.Select(selStart, selLength);
        SendMessage(box.Handle, EM_SETSCROLLPOS, IntPtr.Zero, ref scrollPos);

        SendMessage(box.Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
        box.Invalidate();
    }
}

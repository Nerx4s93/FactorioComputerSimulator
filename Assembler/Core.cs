using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler;

internal class Core
{
    private RichTextBox _richTextBox;

    private readonly CodeEditor _codeEditor;
    private readonly InstructionCompiler _instructionCompiler;
    private readonly CodeSimulator _codeSimulator;

    public Core(RichTextBox richTextBox)
    {
        _richTextBox = richTextBox;
        _codeEditor = new CodeEditor(richTextBox);
        _instructionCompiler = new InstructionCompiler();
        _codeSimulator = new CodeSimulator();
    }

    public CompiledLine[] StartCompile()
    {
        return _instructionCompiler.StartCompile(_richTextBox.Lines);
    }

    public SimulatorHandle StartSimulation()
    {
        var code = StartCompile();
        return _codeSimulator.StartSimulation(code);
    }
}
namespace FactorioComputerSimulator.Assembler.Simulation;

public class SimulatorHandle
{
    private readonly CompiledLine[] _code;

    private int _pc = 0;

    public readonly Memory Rom;
    public readonly Memory Ram;
    public readonly Registers Registers;

    public SimulatorHandle(CompiledLine[] code, int romSize, int ramSize)
    {
        _code = code;

        Rom = new Memory(romSize);
        Ram = new Memory(ramSize);
        Registers = new Registers();

        IncludeCode(code);
    }

    public int PC => _pc;
    public bool IsFinished => _pc >= Rom.Size;

    private void IncludeCode(CompiledLine[] code)
    {
        var index = 0;

        foreach (var block in code)
        {
            foreach (var part in block.BinaryParts)
            {
                Rom[index] = Convert.ToByte(part, 2);
                index += 1;
            }
        }
    }

    public void Step()
    {
        if (IsFinished)
        {
            return;
        }

        var opcode = Rom[_pc];
        var infoByte = Rom[_pc + 1];
        var commandType = infoByte >> 6;
        int argsCount = (infoByte >> 3) & 0b111;

        if (_pc + 1 + argsCount >= Rom.Size)
        {
            throw new Exception("Не хватает аргументов в ROM.");
        }

        var args = new byte[argsCount];
        Array.Copy(Rom.Raw, _pc + 2, args, 0, argsCount);

        ExecuteInstruction(opcode, commandType, args);
    }

    private void ExecuteInstruction(int id, int commandType, byte[] args)
    {
        var command = CommandRegistry.GetById(id);
        command.Execute(ref _pc, commandType, args, Registers, Ram);
    }

    public void Reset()
    {
        _pc = 0;
    }

    public int? GetNextSourceLineIndex()
    {
        var offset = 0;

        for (int i = 0; i < _code.Length; i++)
        {
            var parts = _code[i].BinaryParts;
            if (offset == _pc)
            {
                return _code[i].SourceLineIndex;
            }

            offset += parts.Length;
            if (_pc < offset)
            {
                return _code[i].SourceLineIndex;
            }
        }

        return null;
    }

}
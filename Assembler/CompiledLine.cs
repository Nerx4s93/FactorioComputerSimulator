namespace FactorioComputerSimulator.Assembler
{
    public struct CompiledLine
    {
        public int SourceLineIndex { get; }
        public string[] BinaryParts { get; }

        public CompiledLine(int sourceLineIndex, string[] binaryParts)
        {
            SourceLineIndex = sourceLineIndex;
            BinaryParts = binaryParts;
        }

        public override string ToString()
        {
            return string.Join(" ", BinaryParts);
        }
    }
}
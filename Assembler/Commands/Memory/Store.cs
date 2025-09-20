using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Memory
{
    internal class Store : Command
    {
        public override string Group => "Memory";
        public override string Name => "store";
        public override int Id => 12;

        public override int GetByteData(int commandType)
        {
            return 2;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            var index = (args[0] << 8) | args[1];
            ram[index] = registers["B"];
            pc += 2 + GetByteData(commandType);
        }
    }
}

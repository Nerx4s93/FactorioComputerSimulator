using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler.Commands.Logic
{
    internal class Not : Command
    {
        public override string Group => "Logic";
        public override string Name => "not";
        public override int Id => 9;

        public override int GetByteData(int commandType)
        {
            return 0;
        }

        public override void Execute(ref int pc, int commandType, byte[] args, Registers registers, Simulation.Memory ram)
        {
            registers["L"] = (byte)~registers["L"];
            pc += 2 + GetByteData(commandType);
        }
    }
}

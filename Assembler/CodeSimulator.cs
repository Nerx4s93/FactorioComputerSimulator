using FactorioComputerSimulator.Assembler.Simulation;

namespace FactorioComputerSimulator.Assembler;

internal class CodeSimulator
{
    public SimulatorHandle StartSimulation(CompiledLine[] code)
    {
        return new SimulatorHandle(code, 1024, 256);
    }
}
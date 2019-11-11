using System.Collections.Generic;

namespace SneakyParticleSystem
{
    public class EmitterConfig
    {
        public IEmitterShape EmitterShape { get; set; }
        public IColorCalculator InitialColorCalculator { get; set; }
        public IColorCalculator FinalColorCalculator { get; set; }
        public ISizeCalculator InitialSizeCalculator { get; set; }
        public int EmissionRatePerSecond { get; set; }
        public int MaximumNumberOfParticles { get; set; }

        public List<IAction> Actions { get; set; }
    }
}
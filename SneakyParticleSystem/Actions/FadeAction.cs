namespace SneakyParticleSystem.Actions
{
    public class FadeAction : IAction
    {
        private readonly int _startingAlpha;
        private readonly int _finalAlpha;

        public FadeAction(int startingAlpha, int finalAlpha)
        {
            _startingAlpha = startingAlpha;
            _finalAlpha = finalAlpha;
        }

        public Particle DoAction(Particle particle, float deltaTime)
        {
            var particleColor = new ColorRgba(particle.Color);
            particleColor.A = (byte)(_finalAlpha + ((_startingAlpha - _finalAlpha) * (1-particle.Life.AgeRatio)));

            var newParticle = new Particle(particle.Position, particle.Velocity, particleColor, particle.StartingColor, particle.EndingColor, particle.Size, particle.Life);

            return newParticle;
        }
    }
}
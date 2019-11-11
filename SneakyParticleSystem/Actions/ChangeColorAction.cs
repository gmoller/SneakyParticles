namespace SneakyParticleSystem.Actions
{
    public class ChangeColorAction : IAction
    {
        private readonly ColorRgba _startingColor;
        private readonly ColorRgba _finalColor;

        public ChangeColorAction(ColorRgba startingColor, ColorRgba finalColor)
        {
            _startingColor = startingColor;
            _finalColor = finalColor;
        }

        public Particle DoAction(Particle particle, float deltaTime)
        {
            var particleColor = ColorRgba.Lerp(particle.StartingColor, particle.EndingColor, particle.Life.AgeRatio);

            var newParticle = new Particle(particle.Position, particle.Velocity, particleColor, particle.StartingColor, particle.EndingColor, particle.Size, particle.Life);

            return newParticle;
        }
    }
}
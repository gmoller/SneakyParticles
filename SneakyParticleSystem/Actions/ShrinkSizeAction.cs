namespace SneakyParticleSystem.Actions
{
    public class ShrinkSizeAction : IAction
    {
        public Particle DoAction(Particle particle, float deltaTime)
        {
            var particleSize = new Size(particle.Size.Maximum, particle.Life.AgeRatio);

            var newParticle = new Particle(particle.Position, particle.Velocity, particle.Color, particle.StartingColor, particle.EndingColor, particleSize, particle.Life);

            return newParticle;
        }
    }
}
namespace SneakyParticleSystem.Actions
{
    public class MoveAction : IAction
    {
        public Particle DoAction(Particle particle, float deltaTime)
        {
            var positionX = particle.Position.X + particle.Velocity.X * deltaTime;
            var positionY = particle.Position.Y + particle.Velocity.Y * deltaTime;

            var newParticle = new Particle(new Position(positionX, positionY), particle.Velocity, particle.Color, particle.StartingColor, particle.EndingColor, particle.Size, particle.Life);

            return newParticle;
        }
    }
}
using System;

namespace SneakyParticleSystem.Actions
{
    public class SizeInterpolaterAction : IAction
    {
        public Particle DoAction(Particle particle, float deltaTime)
        {
            var particleSize = new Size();

            var newParticle = new Particle(particle.Position, particle.Velocity, particle.Color, particle.StartingColor, particle.EndingColor, particleSize, particle.Life);

            return newParticle;
        }
    }
}
namespace SneakyParticleSystem
{
    public interface IAction
    {
        Particle DoAction(Particle particle, float deltaTime);
    }
}
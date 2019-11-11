namespace SneakyParticleSystem
{
    public interface IEmitterShape
    {
        Vector2 GetLocation();
        Velocity GetVelocity(Vector2 point);
    }
}
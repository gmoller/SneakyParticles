namespace SneakyParticleSystem.Shapes
{
    public class PointEmitter : IEmitterShape
    {
        private readonly IInitialVelocityCalculator _initialVelocityCalculator;

        public PointEmitter(IInitialVelocityCalculator initialVelocityCalculator)
        {
            _initialVelocityCalculator = initialVelocityCalculator;
        }

        public Vector2 GetLocation()
        {
            return new Vector2(0, 0);
        }

        public Velocity GetVelocity(Vector2 point)
        {
            return _initialVelocityCalculator.GetVelocity(point);
        }
    }
}
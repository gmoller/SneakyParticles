using System;

namespace SneakyParticleSystem.Shapes
{
    public class CircleEmitter : IEmitterShape
    {
        private const double TWO_PI = Math.PI * 2;

        private readonly float _radius;
        private readonly IInitialVelocityCalculator _initialVelocityCalculator;
        private readonly IRandom _random;

        public CircleEmitter(float radius, IInitialVelocityCalculator initialVelocityCalculator, IRandom random)
        {
            _radius = radius;
            _initialVelocityCalculator = initialVelocityCalculator;
            _random = random;
        }

        public Vector2 GetLocation()
        {
            var angleInRadians = (float)_random.NextDouble() * TWO_PI;

            var x = (float)(Math.Cos(angleInRadians) * _radius);
            var y = (float)(Math.Sin(angleInRadians) * _radius);

            return new Vector2(x, y);
        }

        public Velocity GetVelocity(Vector2 point)
        {
            return _initialVelocityCalculator.GetVelocity(point);
        }
    }
}
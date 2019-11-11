using System;

namespace SneakyParticleSystem
{
    public interface IInitialVelocityCalculator
    {
        Velocity GetVelocity(Vector2 point);
    }

    public class ThreeSixty : IInitialVelocityCalculator
    {
        private readonly int _min;
        private readonly int _max;
        private readonly IRandom _random;

        public ThreeSixty(int minSpeed, int maxSpeed, IRandom random)
        {
            _min = minSpeed;
            _max = maxSpeed + 1;
            _random = random;
        }

        public Velocity GetVelocity(Vector2 point)
        {
            var angle = _random.Next(0, 360); // 0..359
            var speed = _random.Next(_min, _max);
            var velocity = new Velocity(angle, speed);

            return velocity;
        }
    }

    public class StraightLine : IInitialVelocityCalculator
    {
        private readonly int _angle;
        private readonly int _min;
        private readonly int _max;
        private readonly IRandom _random;

        public StraightLine(int angle, int minSpeed, int maxSpeed, IRandom random)
        {
            _angle = angle;
            _min = minSpeed;
            _max = maxSpeed + 1;
            _random = random;
        }

        public Velocity GetVelocity(Vector2 point)
        {
            var speed = _random.Next(_min, _max);
            var velocity = new Velocity(_angle, speed);

            return velocity;
        }
    }

    public class Normal : IInitialVelocityCalculator
    {
        private readonly int _min;
        private readonly int _max;
        private readonly IRandom _random;

        public Normal(int minSpeed, int maxSpeed, IRandom random)
        {
            _min = minSpeed;
            _max = maxSpeed + 1;
            _random = random;
        }

        public Velocity GetVelocity(Vector2 point)
        {
            // get angle from point
            var angleInRadians = Math.Atan2(point.Y, point.X);
            var angleinDegrees = 180 * angleInRadians / Math.PI;
            var angle = (360 + Math.Round(angleinDegrees)) % 360;

            var speed = _random.Next(_min, _max);
            var velocity = new Velocity((float)angle, speed);

            return velocity;
        }
    }
}
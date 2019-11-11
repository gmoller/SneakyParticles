using System;

namespace SneakyParticleSystem
{
    public struct Velocity
    {
        private Vector2 _velocity;

        public float X => _velocity.X;
        public float Y => _velocity.Y;

        public Velocity(Vector2 vector)
        {
            _velocity = new Vector2(vector);
        }

        public Velocity(float angle, float speed)
        {
            var angleInRadians = angle * Math.PI / 180.0f;
            var velocityX = (float)(speed * Math.Cos(angleInRadians));
            var velocityY = (float)(speed * Math.Sin(angleInRadians));
            _velocity = new Vector2(velocityX, velocityY);
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }
    }
}
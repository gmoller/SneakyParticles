namespace SneakyParticleSystem
{
    public struct Position
    {
        private Vector2 _position;

        public float X => _position.X;
        public float Y => _position.Y;

        public Position(float x, float y)
        {
            _position = new Vector2(x, y);
        }

        public Position(Vector2 position)
        {
            _position = position;
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }
    }
}
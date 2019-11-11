namespace SneakyParticleSystem.Shapes
{
    public class LineEmitter : IEmitterShape
    {
        private readonly Vector2 _point1;
        private readonly Vector2 _point2;
        private readonly float _slope;
        private readonly bool _lineIsVertical;
        private readonly IInitialVelocityCalculator _initialVelocityCalculator;
        private readonly IRandom _random;

        public LineEmitter(Vector2 point1, Vector2 point2, IInitialVelocityCalculator initialVelocityCalculator, IRandom random)
        {
            _point1 = point1;
            _point2 = point2;
            if (point1.X == point2.X)
            {
                _lineIsVertical = true;
            }
            else
            {
                _slope = (point2.Y - point1.Y) / (point2.X - point1.X);
            }
            _initialVelocityCalculator = initialVelocityCalculator;
            _random = random;
        }

        public Vector2 GetLocation()
        {
            var n = (float)_random.NextDouble();

            if (_lineIsVertical)
            {
                var x = _point1.X;
                var y = (_point2.Y - _point1.Y) * n + _point1.Y;

                return new Vector2(x, y);
            }
            else
            {
                var x = (_point2.X - _point1.X) * n + _point1.X;
                var y = _slope * (x - _point1.X) + _point1.Y;

                return new Vector2(x, y);
            }
        }

        public Velocity GetVelocity(Vector2 point)
        {
            return _initialVelocityCalculator.GetVelocity(point);
        }
    }
}
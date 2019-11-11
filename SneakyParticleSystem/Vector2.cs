namespace SneakyParticleSystem
{
    public struct Vector2
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2(Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;

            return value1;
        }

        public bool Equals(Vector2 other)
        {
            return IsApproximatelyEqual(X, other.X, 0.00001) && IsApproximatelyEqual(Y, other.Y, 0.000000000001d);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                return Equals((Vector2)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }

        private bool IsApproximatelyEqual(float x, float y, double acceptableVariance)
        {
            double variance = x > y ? x - y : y - x;
            return variance < acceptableVariance;

            //or
            //return Math.Abs(x - y) < acceptableVariance;
        }
    }
}
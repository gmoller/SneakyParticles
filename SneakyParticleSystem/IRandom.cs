using System;

namespace SneakyParticleSystem
{
    public interface IRandom
    {
        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        int Next(int minValue, int maxValue);

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
        double NextDouble();

        /// <summary>
        /// Returns a random floating-point number that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A single-precision floating point number that is greater than or equal to minValue, and less than maxValue. If minValue equals maxValue, minValue is returned.</returns>
        float NextFloat(float min, float max);
    }

    public class RandomWrapper : IRandom
    {
        private Random _random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }

        public float NextFloat(float minValue, float maxValue)
        {
            if (maxValue < minValue) throw new ArgumentException("maxValue must be greater than or equal to minValue.", "maxValue");

            var next = _random.NextDouble();

            return (float)(minValue + (next * (maxValue - minValue)));
        }
    }

    public class TestRandom : IRandom
    {
        private double _rnd;

        public TestRandom(double rnd)
        {
            _rnd = rnd;
        }

        public int Next(int minValue, int maxValue)
        {
            return (int)_rnd;
        }

        public double NextDouble()
        {
            return _rnd;
        }

        public float NextFloat(float min, float max)
        {
            return (float)_rnd;
        }
    }
}
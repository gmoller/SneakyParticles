//using System;

//namespace SneakyParticleSystem
//{
//    public static class RandomExtensions
//    {
//        /// <summary>
//        /// Returns a random float between float.MinValue and float.MaxValue.
//        /// </summary>
//        /// <param name="random"></param>
//        /// <returns></returns>
//        public static float NextFloat(this Random random)
//        {
//            double mantissa = (random.NextDouble() * 2.0) - 1.0;
//            // choose -149 instead of -126 to also generate subnormal floats (*)
//            double exponent = Math.Pow(2.0, random.Next(-126, 128));
//            return (float)(mantissa * exponent);
//        }
//    }
//}
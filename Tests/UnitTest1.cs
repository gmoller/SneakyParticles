using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SneakyParticleSystem;
using SneakyParticleSystem.Shapes;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCircleEmitter()
        {
            var random = new TestRandom(0.0d);
            var emitterShape = new CircleEmitter(1.0f, new ThreeSixty(1, 10, random), random); // 0 degrees
            var location = emitterShape.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(new Vector2(1, 0), location);

            random = new TestRandom(0.25d);
            emitterShape = new CircleEmitter(1.0f, new ThreeSixty(1, 10, random), random); // 90 degrees
            location = emitterShape.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(new Vector2(0, 1), location);

            random = new TestRandom(0.5d);
            emitterShape = new CircleEmitter(1.0f, new ThreeSixty(1, 10, random), random); // 180 degrees
            location = emitterShape.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(new Vector2(-1, 0), location);

            random = new TestRandom(0.75d);
            emitterShape = new CircleEmitter(1.0f, new ThreeSixty(1, 10, random), random); // 270 degrees
            location = emitterShape.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(new Vector2(0, -1), location);

            random = new TestRandom(1.0d);
            emitterShape = new CircleEmitter(1.0f, new ThreeSixty(1, 10, random), random); // 360 degrees
            location = emitterShape.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(new Vector2(1, 0), location);
        }

        [TestMethod]
        public void TestNormalVelocityCreater()
        {
            var normal = new Normal(1, 1, new TestRandom(1.0d));
            var velocity = normal.GetVelocity(new Vector2(1, 0));
            Console.WriteLine(velocity);
            Assert.AreEqual(new Velocity(new Vector2(1, 0)), velocity);

            normal = new Normal(1, 1, new TestRandom(1.0d));
            velocity = normal.GetVelocity(new Vector2(0, 1));
            Console.WriteLine(velocity);
            Assert.AreEqual(new Velocity(new Vector2(0, 1)), velocity);
        }
    }
}
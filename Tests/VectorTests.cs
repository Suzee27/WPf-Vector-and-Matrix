using CustomStruct;
using NUnit.Framework;
using System;

namespace Tests
{
    public class VectorTests
    {
        private CustomVector v1;
        private CustomVector v2;
        [SetUp]
        public void Setup()
        {
            v1 = new CustomVector(20, 10);
            v2 = new CustomVector(10, 20);
        }

        [Test]
        public void TestVectorAddition()
        {
            var v3 = v1.Add(v1, v2);
            var expected = new CustomVector(30, 30);

            Assert.That(v3, Is.EqualTo(expected));
        }

        [Test]
        public void TestAngleBetween()
        {
            var angle = Math.Round(CustomVector.Angle(v1, v2),2);

            Assert.That(angle, Is.EqualTo(36.87));
        }
    }
}
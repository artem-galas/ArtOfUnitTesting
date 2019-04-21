using System;

using NUnit.Framework;

using LogAn;

namespace Tests
{
    class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator memCalculator = MakeCalculator();

            int lastSum = memCalculator.Sum();

            Assert.AreEqual(0, lastSum);
        }

        [Test]
        public void Add_WhenCalled_ChangeSum()
        {
            MemCalculator memCalculator = MakeCalculator();

            memCalculator.Add(1);
            int sum = memCalculator.Sum();

            Assert.AreEqual(1, sum);
        }

        private MemCalculator MakeCalculator() {
            return new MemCalculator();
        }
    }
}
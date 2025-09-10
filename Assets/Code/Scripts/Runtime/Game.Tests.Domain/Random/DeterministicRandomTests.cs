using Game.Domain.Random;
using NUnit.Framework;

namespace Game.Tests.Domain.Random
{
    public sealed class DeterministicRandomTests
    {
        [Test]
        public void SameSeed_Produces_Same_Sequence()
        {
            var r1 = new DeterministicRandom(12345);
            var r2 = new DeterministicRandom(12345);

            for (var i = 0; i < 100; i++)
            {
                Assert.AreEqual(r1.Next(), r2.Next());
            }
        }

        [Test]
        public void Range_Is_Within_Bounds()
        {
            var r = new DeterministicRandom(42);

            for (var i = 0; i < 1000; i++)
            {
                var v = r.Range(3, 9); // [3..8]
                Assert.GreaterOrEqual(v, 3);
                Assert.Less(v, 9);
            }
        }
    }
}
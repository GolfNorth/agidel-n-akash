using Game.Domain.Core;
using NUnit.Framework;

namespace Game.Tests.Domain.Core
{
    public sealed class CoordTests
    {
        [Test]
        public void Equality_And_HashCode_Work()
        {
            var a = new Coord(2, 3);
            var b = new Coord(2, 3);
            var c = new Coord(3, 2);

            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            Assert.AreNotEqual(a, c);
        }

        [Test]
        public void Operators_Add_Sub_ToString()
        {
            var a = new Coord(1, 2);
            var b = new Coord(3, 4);

            var sum = a + b;
            var dif = b - a;

            Assert.AreEqual(new Coord(4, 6), sum);
            Assert.AreEqual(new Coord(2, 2), dif);
            Assert.AreEqual("(1,2)", a.ToString());
        }

        [Test]
        public void CoordX_ToIndex_FromIndex_Roundtrip()
        {
            var w = 5;
            var c = new Coord(4, 2);
            var idx = CoordX.ToIndex(c, w);
            var back = CoordX.FromIndex(idx, w);

            Assert.AreEqual(c, back);
        }
    }
}
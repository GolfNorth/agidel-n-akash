using System.Linq;
using Game.Domain.Core;
using Game.Domain.Utils;
using NUnit.Framework;

namespace Game.Tests.Domain.Utils
{
    /// <summary>
    /// Tests for common coordinate selection helpers:
    /// Neighbors4, Neighbors8, Line, and InRadius.
    /// </summary>
    public sealed class SelectorsTests
    {
        [Test]
        public void Neighbors4_Respects_Bounds_And_Counts()
        {
            const int W = 3;
            const int H = 3;

            var center = new Coord(1, 1);
            var n4Center = Selectors.Neighbors4(center, W, H).ToArray();
            Assert.AreEqual(4, n4Center.Length);

            var corner = new Coord(0, 0);
            var n4Corner = Selectors.Neighbors4(corner, W, H).ToArray();
            Assert.AreEqual(2, n4Corner.Length);

            var edgeTop = new Coord(1, 0);
            var n4EdgeTop = Selectors.Neighbors4(edgeTop, W, H).ToArray();
            Assert.AreEqual(3, n4EdgeTop.Length);
        }

        [Test]
        public void Neighbors8_Respects_Bounds_And_Counts()
        {
            const int W = 3;
            const int H = 3;

            var center = new Coord(1, 1);
            var n8Center = Selectors.Neighbors8(center, W, H).ToArray();
            Assert.AreEqual(8, n8Center.Length);

            var corner = new Coord(0, 0);
            var n8Corner = Selectors.Neighbors8(corner, W, H).ToArray();
            Assert.AreEqual(3, n8Corner.Length);

            var edgeTop = new Coord(1, 0);
            var n8EdgeTop = Selectors.Neighbors8(edgeTop, W, H).ToArray();
            Assert.AreEqual(5, n8EdgeTop.Length);
        }

        [Test]
        public void Line_Produces_Correct_Coordinates()
        {
            const int W = 4;
            const int H = 3;

            var row = Selectors.Line(index: 2, axis: Axis.Horizontal, width: W, height: H).ToArray();
            Assert.AreEqual(W, row.Length);

            var col = Selectors.Line(index: 1, axis: Axis.Vertical, width: W, height: H).ToArray();
            Assert.AreEqual(H, col.Length);
        }

        [Test]
        public void InRadius_Counts_And_Includes_Are_Correct()
        {
            const int W = 5;
            const int H = 5;

            var center = new Coord(2, 2);
            var r1Center = Selectors.InRadius(center, r: 1, width: W, height: H).ToArray();
            Assert.AreEqual(9, r1Center.Length);

            var corner = new Coord(0, 0);
            var r1Corner = Selectors.InRadius(corner, r: 1, width: W, height: H).ToArray();
            Assert.AreEqual(4, r1Corner.Length);
        }
    }
}
using Game.Domain.Board;
using Game.Domain.Core;
using Game.Domain.Utils;
using NUnit.Framework;

namespace Game.Tests.Domain.Utils
{
    public sealed class ConnectivityTests
    {
        [Test]
        public void TopToBottomPath_Exists_On_Straight_Column()
        {
            var b = new BoardState(3, 3);
            b.SetBase(new Coord(1, 0), "R");
            b.SetBase(new Coord(1, 1), "R");
            b.SetBase(new Coord(1, 2), "R");

            bool ok = Connectivity.ExistsTopToBottomPath(
                b,
                isOpen: c => b.Get(c).Base == "R",
                canTraverse: null,
                orthogonalOnly: true
            );

            Assert.IsTrue(ok);
        }

        [Test]
        public void TopToBottomPath_Fails_When_Broken()
        {
            var b = new BoardState(3, 3);
            b.SetBase(new Coord(1, 0), "R");
            b.SetBase(new Coord(1, 2), "R"); // gap at (1,1)

            var ok = Connectivity.ExistsTopToBottomPath(
                b,
                isOpen: c => b.Get(c).Base == "R",
                canTraverse: null,
                orthogonalOnly: true
            );

            Assert.IsFalse(ok);
        }

        [Test]
        public void CanTraverse_Can_Block_Step()
        {
            var b = new BoardState(2, 2);

            // Open a straight vertical path in the left column
            b.SetBase(new Coord(0, 0), "R");
            b.SetBase(new Coord(0, 1), "R");

            // The only way to reach the bottom is from (0,0) -> (0,1).
            // Block exactly this step.
            var ok = Connectivity.ExistsTopToBottomPath(
                b,
                isOpen: c => b.Get(c).Base == "R",
                canTraverse: (from, to) => !(from is { X: 0, Y: 0 } && to is { X: 0, Y: 1 }),
                orthogonalOnly: true
            );

            Assert.IsFalse(ok);
        }
    }
}
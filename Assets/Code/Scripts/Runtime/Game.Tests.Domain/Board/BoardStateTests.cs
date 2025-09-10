using Game.Domain.Board;
using Game.Domain.Core;
using NUnit.Framework;

namespace Game.Tests.Domain.Board
{
    public sealed class BoardStateTests
    {
        [Test]
        public void InBounds_Works()
        {
            var b = new BoardState(3, 2);

            Assert.IsTrue(b.InBounds(new Coord(0, 0)));
            Assert.IsTrue(b.InBounds(new Coord(2, 1)));
            Assert.IsFalse(b.InBounds(new Coord(-1, 0)));
            Assert.IsFalse(b.InBounds(new Coord(3, 0)));
            Assert.IsFalse(b.InBounds(new Coord(0, 2)));
        }

        [Test]
        public void SetBase_And_Clone_Copy_Content()
        {
            var b = new BoardState(2, 2);

            b.SetBase(new Coord(1, 0), "A");
            b.Get(new Coord(1, 0)).Overlays.Add("O1");
            b.Get(new Coord(1, 0)).Markers.Add("M1");

            var copy = b.Clone();

            Assert.AreEqual("A", copy.Get(new Coord(1, 0)).Base);
            Assert.IsTrue(copy.Get(new Coord(1, 0)).Overlays.Contains("O1"));
            Assert.IsTrue(copy.Get(new Coord(1, 0)).Markers.Contains("M1"));

            // Ensure deep copy
            copy.SetBase(new Coord(1, 0), "B");
            Assert.AreEqual("A", b.Get(new Coord(1, 0)).Base);
        }

        [Test]
        public void ClearLine_Works_For_Row_And_Column()
        {
            var b = new BoardState(3, 3);

            // Fill
            for (var y = 0; y < b.Height; y++)
            {
                for (var x = 0; x < b.Width; x++)
                {
                    b.SetBase(new Coord(x, y), "X");
                }
            }

            b.ClearLine(1, Axis.Horizontal); // clear y=1
            Assert.AreEqual(Tags.None, b.Get(new Coord(0, 1)).Base);
            Assert.AreEqual(Tags.None, b.Get(new Coord(2, 1)).Base);
            Assert.AreEqual("X", b.Get(new Coord(0, 0)).Base);

            b.ClearLine(2, Axis.Vertical); // clear x=2
            Assert.AreEqual(Tags.None, b.Get(new Coord(2, 0)).Base);
            Assert.AreEqual(Tags.None, b.Get(new Coord(2, 2)).Base);
        }

        [Test]
        public void Throws_On_Row_Index_Out_Of_Range()
        {
            var b = new BoardState(3, 2);

            Assert.Throws<DomainException>(() => { b.ClearLine(-1, Axis.Horizontal); });

            Assert.Throws<DomainException>(() =>
            {
                b.ClearLine(2, Axis.Horizontal); // Height == 2 → max index 1
            });
        }

        [Test]
        public void Throws_On_Column_Index_Out_Of_Range()
        {
            var b = new BoardState(3, 2);

            Assert.Throws<DomainException>(() => { b.ClearLine(-1, Axis.Vertical); });

            Assert.Throws<DomainException>(() =>
            {
                b.ClearLine(3, Axis.Vertical); // Width == 3 → max index 2
            });
        }
    }
}
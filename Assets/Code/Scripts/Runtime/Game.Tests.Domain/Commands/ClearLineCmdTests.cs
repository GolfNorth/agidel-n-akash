using Game.Domain.Commands;
using Game.Domain.Core;
using Game.Domain.Events;
using Game.Domain.State;
using Game.Tests.Domain.Events;
using NUnit.Framework;

namespace Game.Tests.Domain.Commands
{
    public sealed class ClearLineCmdTests
    {
        [Test]
        public void Clears_Row_And_Undo_Restores()
        {
            var s = new GameState(3, 3);
            for (int x = 0; x < 3; x++)
            {
                s.Board.SetBase(new Coord(x, 1), "X");
                s.Board.Get(new Coord(x, 1)).Overlays.Add("O");
                s.Board.Get(new Coord(x, 1)).Markers.Add("M");
            }

            var sink = new InMemoryEventSink();
            var cmd = new ClearLineCmd(Axis.Horizontal, 1);

            cmd.Do(s, sink);
            Assert.AreEqual(Tags.None, s.Board.Get(new Coord(0, 1)).Base);
            Assert.AreEqual(GameEvent.LineCleared, sink.Items[0].Evt);

            cmd.Undo(s, sink);
            Assert.AreEqual("X", s.Board.Get(new Coord(0, 1)).Base);
            Assert.IsTrue(s.Board.Get(new Coord(0, 1)).Overlays.Contains("O"));
            Assert.IsTrue(s.Board.Get(new Coord(0, 1)).Markers.Contains("M"));
        }

        [Test]
        public void Clears_Column_And_Undo_Restores()
        {
            var s = new GameState(3, 3);
            for (int y = 0; y < 3; y++)
            {
                s.Board.SetBase(new Coord(2, y), "X");
            }

            var sink = new InMemoryEventSink();
            var cmd = new ClearLineCmd(Axis.Vertical, 2);

            cmd.Do(s, sink);
            Assert.AreEqual(Tags.None, s.Board.Get(new Coord(2, 0)).Base);

            cmd.Undo(s, sink);
            Assert.AreEqual("X", s.Board.Get(new Coord(2, 0)).Base);
            Assert.AreEqual("X", s.Board.Get(new Coord(2, 2)).Base);
        }
    }
}

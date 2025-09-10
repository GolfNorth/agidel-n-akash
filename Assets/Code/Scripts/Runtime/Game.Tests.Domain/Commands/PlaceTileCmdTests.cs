using Game.Domain.Commands;
using Game.Domain.Core;
using Game.Domain.Events;
using Game.Domain.State;
using Game.Tests.Domain.Events;
using NUnit.Framework;

namespace Game.Tests.Domain.Commands
{
    public sealed class PlaceTileCmdTests
    {
        [Test]
        public void Places_Base_And_Emits_Event()
        {
            var s = new GameState(3, 3);
            var sink = new InMemoryEventSink();
            var cmd = new PlaceTileCmd("River", new Coord(1, 0), ownerId: 0);

            cmd.Do(s, sink);

            Assert.AreEqual("River", s.Board.Get(new Coord(1, 0)).Base);
            Assert.AreEqual(1, sink.Items.Count);
            Assert.AreEqual(GameEvent.TilePlaced, sink.Items[0].Evt);

            var payload = (PlaceTilePayload)sink.Items[0].Payload;
            Assert.AreEqual("River", payload.ProtoId);
            Assert.AreEqual(0, payload.OwnerId);
            Assert.AreEqual(new Coord(1, 0), payload.Pos);
        }

        [Test]
        public void Undo_Restores_Previous_Base_And_Emits_TileRemoved()
        {
            var s = new GameState(3, 3);
            s.Board.SetBase(new Coord(1, 1), "Stone");

            var sink = new InMemoryEventSink();
            var cmd = new PlaceTileCmd("River", new Coord(1, 1), ownerId: 0);

            cmd.Do(s, sink);
            cmd.Undo(s, sink);

            Assert.AreEqual("Stone", s.Board.Get(new Coord(1, 1)).Base);
            Assert.IsTrue(sink.Items.Exists(e => e.Evt == GameEvent.TileRemoved));
        }
    }
}
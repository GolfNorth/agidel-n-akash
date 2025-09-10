using Game.Domain.Commands;
using Game.Domain.Core;
using Game.Domain.Events;
using Game.Domain.State;
using Game.Tests.Domain.Events;
using NUnit.Framework;

namespace Game.Tests.Domain.Commands
{
    public sealed class AdvanceTurnCmdTests
    {
        [Test]
        public void Do_Advances_Turn_And_Emits_Event()
        {
            var s = new GameState(2, 2);
            var sink = new InMemoryEventSink();
            var cmd = new AdvanceTurnCmd();

            cmd.Do(s, sink);

            Assert.AreEqual(1, s.Turn);
            Assert.AreEqual(Players.AkashId, s.CurrentPlayerId);

            Assert.AreEqual(1, sink.Items.Count);
            Assert.AreEqual(GameEvent.TurnAdvanced, sink.Items[0].Evt);
            var p = (TurnAdvancedPayload)sink.Items[0].Payload;
            Assert.AreEqual(1, p.Turn);
            Assert.AreEqual(Players.AkashId, p.CurrentPlayerId);
        }

        [Test]
        public void Undo_Reverts_Turn_And_Emits_Event()
        {
            var s = new GameState(2, 2);
            var sink = new InMemoryEventSink();
            var cmd = new AdvanceTurnCmd();

            cmd.Do(s, sink);
            cmd.Undo(s, sink);

            Assert.AreEqual(0, s.Turn);
            Assert.AreEqual(Players.AgidelId, s.CurrentPlayerId);
        }
    }
}
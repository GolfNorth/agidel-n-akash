using Game.Domain.Core;
using Game.Domain.State;
using NUnit.Framework;

namespace Game.Tests.Domain.State
{
    public sealed class GameStateTurnTests
    {
        [Test]
        public void Agidel_Starts_And_Rotation_Works()
        {
            var s = new GameState(4, 4);

            Assert.AreEqual(Players.AgidelId, s.CurrentPlayerId);
            Assert.AreEqual(0, s.Turn);

            s.NextPlayer();
            Assert.AreEqual(Players.AkashId, s.CurrentPlayerId);
            Assert.AreEqual(1, s.Turn);

            s.RevertPlayer();
            Assert.AreEqual(Players.AgidelId, s.CurrentPlayerId);
            Assert.AreEqual(0, s.Turn);
        }
    }
}
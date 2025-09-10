using Game.Domain.Core;
using NUnit.Framework;

namespace Game.Tests.Domain.Core
{
    public sealed class PlayersTests
    {
        [Test]
        public void Agidel_Starts_And_Next_Toggles()
        {
            Assert.AreEqual(Players.AgidelId, 0);
            Assert.AreEqual(Players.AkashId, 1);

            Assert.AreEqual(Players.AkashId, Players.Next(Players.AgidelId));
            Assert.AreEqual(Players.AgidelId, Players.Next(Players.AkashId));

            Assert.AreEqual(Players.AkashId, Players.Other(Players.AgidelId));
            Assert.AreEqual(Players.AgidelId, Players.Other(Players.AkashId));
        }
    }
}

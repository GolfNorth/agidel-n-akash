using Game.Domain.Core;
using Game.Domain.Placement;
using Game.Domain.State;
using NUnit.Framework;

namespace Game.Tests.Domain.Placement
{
    public sealed class PlacementValidatorTests
    {
        [Test]
        public void Allows_On_Empty_Rejects_On_Filled()
        {
            var s = new GameState(3, 3);
            var provider = new FakeRuleProvider();
            provider.Register("Any", new EmptyCellRule());

            var v = new PlacementValidator(s, provider);

            var pos = new Coord(1, 1);

            Assert.IsTrue(v.CanPlace("Any", pos, playerId: 0, out _));

            s.Board.SetBase(pos, "X");

            Assert.IsFalse(v.CanPlace("Any", pos, 0, out var reason));
            Assert.IsNotNull(reason);
        }

        [Test]
        public void Unknown_Prototype_Is_Rejected()
        {
            var s = new GameState(2, 2);
            var provider = new FakeRuleProvider();
            var v = new PlacementValidator(s, provider);

            Assert.IsFalse(v.CanPlace("Unknown", new Coord(0, 0), 0, out var reason));
            Assert.IsTrue(reason.Contains("Unknown"));
        }

        [Test]
        public void ComputeValidCells_Scans_And_Returns_Set()
        {
            var s = new GameState(2, 2);
            var provider = new FakeRuleProvider();
            provider.Register("Any", new EmptyCellRule());

            s.Board.SetBase(new Coord(0, 0), "X"); // one cell blocked

            var v = new PlacementValidator(s, provider);
            var set = v.ComputeValidCells("Any", 0);

            Assert.AreEqual(3, set.Count);
            Assert.IsFalse(set.Contains(new Coord(0, 0)));
        }
    }
}

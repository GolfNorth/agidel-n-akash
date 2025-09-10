using System.Collections.Generic;
using Game.Domain.Core;
using Game.Domain.Placement;

namespace Game.Tests.Domain.Placement
{
    /// <summary>
    /// A tiny rule that only allows placement on empty cells.
    /// </summary>
    public sealed class EmptyCellRule : ITilePlacementRule
    {
        public PlacementPhase Phase { get { return PlacementPhase.Cell; } }

        public bool CanPlace(in PlacementCtx ctx, out string reason)
        {
            if (ctx.State.Board.Get(ctx.Target).Base != Tags.None)
            {
                reason = "Not empty.";
                return false;
            }

            reason = null;
            return true;
        }
    }

    /// <summary>
    /// Fake provider that serves a single hardcoded rule set for known ids.
    /// </summary>
    public sealed class FakeRuleProvider : IPlacementRuleProvider
    {
        private readonly Dictionary<string, List<ITilePlacementRule>> _map;

        public FakeRuleProvider()
        {
            _map = new Dictionary<string, List<ITilePlacementRule>>();
        }

        public void Register(string protoId, params ITilePlacementRule[] rules)
        {
            _map[protoId] = new List<ITilePlacementRule>(rules);
        }

        public IEnumerable<ITilePlacementRule> GetRules(string protoId)
        {
            if (_map.TryGetValue(protoId, out var list))
            {
                return list;
            }
            return null; // unknown id
        }
    }
}
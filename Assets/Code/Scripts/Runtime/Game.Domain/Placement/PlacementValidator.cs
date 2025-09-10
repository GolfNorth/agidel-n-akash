using System.Collections.Generic;
using Game.Domain.Core;

namespace Game.Domain.Placement
{
    /// <summary>
    /// Thin orchestrator that evaluates prototype-bound placement rules.
    /// </summary>
    public sealed class PlacementValidator
    {
        private readonly GameState _state;
        private readonly IPlacementRuleProvider _rules;

        /// <summary>
        /// Creates a validator bound to a game state and a rule provider.
        /// </summary>
        public PlacementValidator(GameState state, IPlacementRuleProvider rules)
        {
            _state = state;
            _rules = rules;
        }

        /// <summary>
        /// Returns whether a tile (by prototype id) can be placed at the position for the player.
        /// If the provider does not know the prototype id, returns false with a reason.
        /// If the provider returns no rules, placement is allowed by default (content has no constraints).
        /// </summary>
        public bool CanPlace(string protoId, Coord pos, int playerId, out string reason)
        {
            // Guard against out-of-bounds to avoid consumer mistakes and index errors.
            if (!_state.Board.InBounds(pos))
            {
                reason = "Out of bounds.";
                return false;
            }

            var rules = _rules.GetRules(protoId);

            if (rules == null)
            {
                reason = $"Unknown prototype: {protoId}";
                return false;
            }

            // Evaluate in phase order with early-out.
            // We avoid LINQ allocations and do a single pass, partitioning by phase.
            var early = new List<ITilePlacementRule>();
            var cell = new List<ITilePlacementRule>();
            var neighborhood = new List<ITilePlacementRule>();
            var late = new List<ITilePlacementRule>();

            foreach (var r in rules)
            {
                switch (r.Phase)
                {
                    case PlacementPhase.Early:
                        early.Add(r);
                        break;
                    case PlacementPhase.Cell:
                        cell.Add(r);
                        break;
                    case PlacementPhase.Neighborhood:
                        neighborhood.Add(r);
                        break;
                    case PlacementPhase.Late:
                        late.Add(r);
                        break;
                    default:
                        late.Add(r);
                        break;
                }
            }

            var ctx = new PlacementCtx(_state, pos, protoId, playerId);

            if (!Run(early, in ctx, out reason))
            {
                return false;
            }

            if (!Run(cell, in ctx, out reason))
            {
                return false;
            }

            if (!Run(neighborhood, in ctx, out reason))
            {
                return false;
            }

            if (!Run(late, in ctx, out reason))
            {
                return false;
            }

            reason = null;

            return true;
        }

        /// <summary>
        /// Computes all valid cells for the given prototype and player by scanning the board
        /// and applying the same rule pipeline per cell.
        /// </summary>
        public HashSet<Coord> ComputeValidCells(string protoId, int playerId)
        {
            var set = new HashSet<Coord>();

            for (var y = 0; y < _state.Board.Height; y++)
            {
                for (var x = 0; x < _state.Board.Width; x++)
                {
                    var c = new Coord(x, y);

                    if (CanPlace(protoId, c, playerId, out _))
                    {
                        set.Add(c);
                    }
                }
            }

            return set;
        }

        private static bool Run(List<ITilePlacementRule> list, in PlacementCtx ctx, out string reason)
        {
            foreach (var rule in list)
            {
                if (!rule.CanPlace(in ctx, out reason))
                {
                    return false;
                }
            }

            reason = null;

            return true;
        }
    }
}
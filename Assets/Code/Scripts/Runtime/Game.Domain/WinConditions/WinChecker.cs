using System.Collections.Generic;
using Game.Domain.State;

namespace Game.Domain.WinConditions
{
    /// <summary>
    /// Aggregates multiple win conditions and evaluates them against a game state.
    /// </summary>
    public sealed class WinChecker
    {
        private readonly List<IWinCondition> _conditions;

        /// <summary>
        /// Creates a new win checker with the given conditions.
        /// </summary>
        public WinChecker(IEnumerable<IWinCondition> conditions)
        {
            _conditions = new List<IWinCondition>(conditions);
        }

        /// <summary>
        /// Evaluates all conditions in order and returns the first satisfied result.
        /// Returns null if no condition is satisfied.
        /// </summary>
        public int? Check(GameState state)
        {
            for (var i = 0; i < _conditions.Count; i++)
            {
                var winner = _conditions[i].Check(state);

                if (winner.HasValue)
                {
                    return winner.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a condition dynamically.
        /// </summary>
        public void AddCondition(IWinCondition condition)
        {
            _conditions.Add(condition);
        }
    }
}
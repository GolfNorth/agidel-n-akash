using System.Collections.Generic;
using Game.Domain.Board;
using Game.Domain.Core;
using Game.Domain.Tiles;

namespace Game.Domain
{
    /// <summary>
    /// Canonical container for all mutable data of a single match.
    /// Holds the board, turn state, player resources, and per-tile runtime data.
    /// Mutations should happen via commands only.
    /// </summary>
    public sealed class GameState
    {
        /// <summary>
        /// Current turn counter (0-based).
        /// </summary>
        public int Turn { get; private set; }

        /// <summary>
        /// Id of the player whose turn it is (e.g., 0 or 1).
        /// </summary>
        public int CurrentPlayerId { get; private set; }

        /// <summary>
        /// Per-player mana (or equivalent resource).
        /// </summary>
        public int[] Mana { get; private set; }

        /// <summary>
        /// The 2D board grid with base/overlays/markers.
        /// </summary>
        public BoardState Board { get; private set; }

        /// <summary>
        /// Runtime state of placed tiles keyed by position.
        /// </summary>
        public Dictionary<Coord, TileRuntime> Tiles { get; private set; }

        /// <summary>
        /// Global variables (string key → string value).
        /// </summary>
        public Dictionary<string, string> Vars { get; private set; }

        /// <summary>
        /// Global counters/stacks (string key → integer value).
        /// </summary>
        public Dictionary<string, int> Stacks { get; private set; }

        /// <summary>
        /// Creates a new game state with a board of the specified size.
        /// </summary>
        public GameState(int width, int height, int players = 2)
        {
            Turn = 0;
            CurrentPlayerId = 0;
            Mana = new int[players];
            Board = new BoardState(width, height);
            Tiles = new Dictionary<Coord, TileRuntime>();
            Vars = new Dictionary<string, string>();
            Stacks = new Dictionary<string, int>();
        }

        /// <summary>
        /// Advances to the next player and increments the turn counter.
        /// </summary>
        public void NextPlayer()
        {
            CurrentPlayerId = (CurrentPlayerId + 1) % Mana.Length;
            Turn++;
        }

        /// <summary>
        /// Creates a deep clone of this state, including board and runtime dictionaries.
        /// </summary>
        public GameState Clone()
        {
            var clone = new GameState(Board.Width, Board.Height, Mana.Length)
            {
                Turn = Turn,
                CurrentPlayerId = CurrentPlayerId
            };

            for (int i = 0; i < Mana.Length; i++)
            {
                clone.Mana[i] = Mana[i];
            }

            clone.Board = Board.Clone();

            foreach (var kv in Tiles)
            {
                clone.Tiles[kv.Key] = kv.Value.Clone();
            }

            foreach (var kv in Vars)
            {
                clone.Vars[kv.Key] = kv.Value;
            }

            foreach (var kv in Stacks)
            {
                clone.Stacks[kv.Key] = kv.Value;
            }

            return clone;
        }
    }
}
using System.Collections.Generic;
using Game.Domain.Core;

namespace Game.Domain.Tiles
{
    /// <summary>
    /// Per-instance runtime data of a tile placed on the board.
    /// Links a prototype id to a position and tracks mutable values.
    /// </summary>
    public sealed class TileRuntime
    {
        /// <summary>
        /// Prototype id of this tile (string key in prototype repo).
        /// </summary>
        public string ProtoId { get; set; }

        /// <summary>
        /// Board coordinate where this tile resides.
        /// </summary>
        public Coord Pos { get; set; }

        /// <summary>
        /// Id of the owning player.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Per-tile counters/stacks (e.g., hit points, charges).
        /// </summary>
        public Dictionary<string, int> Stacks { get; private set; }

        /// <summary>
        /// Per-tile variables (string key → string value).
        /// </summary>
        public Dictionary<string, string> Vars { get; private set; }

        /// <summary>
        /// Creates a new runtime container with empty stacks and vars.
        /// </summary>
        public TileRuntime()
        {
            Stacks = new Dictionary<string, int>();
            Vars = new Dictionary<string, string>();
        }

        /// <summary>
        /// Creates a deep clone of this runtime instance.
        /// </summary>
        public TileRuntime Clone()
        {
            var clone = new TileRuntime
            {
                ProtoId = ProtoId,
                Pos = Pos,
                OwnerId = OwnerId
            };

            foreach (var kv in Stacks)
            {
                clone.Stacks[kv.Key] = kv.Value;
            }

            foreach (var kv in Vars)
            {
                clone.Vars[kv.Key] = kv.Value;
            }

            return clone;
        }
    }
}
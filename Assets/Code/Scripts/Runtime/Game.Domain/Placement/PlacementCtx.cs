using Game.Domain.Core;

namespace Game.Domain.Placement
{
    /// <summary>
    /// Read-only context passed to placement rules.
    /// Holds the current game state, the prototype id being placed,
    /// the target coordinate, and the acting player id.
    /// </summary>
    public readonly struct PlacementCtx
    {
        /// <summary>
        /// The current mutable match state.
        /// </summary>
        public GameState State { get; }

        /// <summary>
        /// The target board coordinate where the tile is to be placed.
        /// </summary>
        public Coord Target { get; }

        /// <summary>
        /// Content-defined identifier of the tile prototype being placed.
        /// </summary>
        public string ProtoId { get; }

        /// <summary>
        /// Id of the acting player (0-based).
        /// </summary>
        public int PlayerId { get; }

        /// <summary>
        /// Creates a new placement context.
        /// </summary>
        public PlacementCtx(GameState state, Coord target, string protoId, int playerId)
        {
            State = state;
            Target = target;
            ProtoId = protoId;
            PlayerId = playerId;
        }
    }
}
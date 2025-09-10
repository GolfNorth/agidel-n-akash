using Game.Domain.Core;

namespace Game.Domain.Events
{
    /// <summary>
    /// Payload for placing or removing a tile on the board.
    /// Contains the prototype identifier, owner id, and target position.
    /// </summary>
    public sealed class PlaceTilePayload
    {
        /// <summary>
        /// Prototype identifier of the tile (content-defined).
        /// </summary>
        public string ProtoId { get; set; }

        /// <summary>
        /// Owner player id (0-based).
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Board coordinate where the tile was placed or removed.
        /// </summary>
        public Coord Pos { get; set; }
    }
}
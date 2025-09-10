namespace Game.Domain.Events
{
    /// <summary>
    /// Enumerates the domain-level events that can be emitted by commands.
    /// These are consumed by Application and Presentation layers to trigger
    /// animations, UI updates, or network synchronization.
    /// </summary>
    public enum GameEvent
    {
        /// <summary>
        /// A tile has been placed on the board.
        /// Payload: <see cref="PlaceTilePayload"/>.
        /// </summary>
        TilePlaced,

        /// <summary>
        /// A tile has been removed from the board (via undo or special effect).
        /// Payload: <see cref="PlaceTilePayload"/>.
        /// </summary>
        TileRemoved,

        /// <summary>
        /// A line (row or column) has been cleared.
        /// Payload: <see cref="ClearLinePayload"/>.
        /// </summary>
        LineCleared,

        /// <summary>
        /// The turn has changed to another player.
        /// Payload: optional.
        /// </summary>
        TurnAdvanced,

        /// <summary>
        /// A placement attempt has been rejected by rules/validator.
        /// Payload: <see cref="TilePlacementRejectedPayload"/>.
        /// </summary>
        TilePlacementRejected,

        /// <summary>
        /// The game has been won (e.g., river path connected).
        /// Payload: <see cref="WinPayload"/>.
        /// </summary>
        GameWon
    }
}

namespace Game.Domain.Events
{
    /// <summary>
    /// Payload for advancing the turn to the next player.
    /// Useful for UI to drive turn banners, timers, etc.
    /// </summary>
    public sealed class TurnAdvancedPayload
    {
        /// <summary>
        /// Turn counter after the change (0-based).
        /// </summary>
        public int Turn { get; set; }

        /// <summary>
        /// Player id who now owns the turn.
        /// </summary>
        public int CurrentPlayerId { get; set; }
    }
}
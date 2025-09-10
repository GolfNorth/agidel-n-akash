namespace Game.Domain.Events
{
    /// <summary>
    /// Payload for signaling a win condition.
    /// Contains the winner id and a human-readable reason.
    /// </summary>
    public sealed class WinPayload
    {
        /// <summary>
        /// Winner player id (0-based). Use -1 to indicate a draw if applicable.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// Optional human-readable reason or code of the win condition.
        /// </summary>
        public string Reason { get; set; }
    }
}

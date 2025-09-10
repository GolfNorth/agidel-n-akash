namespace Game.Domain.Core
{
    /// <summary>
    /// Canonical player identifiers used throughout the domain.
    /// </summary>
    public static class Players
    {
        /// <summary>
        /// Total number of players in a match.
        /// </summary>
        public const int Count = 2;

        /// <summary>
        /// First player (Agidel). Always starts the match.
        /// </summary>
        public const int AgidelId = 0;

        /// <summary>
        /// Second player (Akash).
        /// </summary>
        public const int AkashId = 1;

        /// <summary>
        /// Returns the other player's id for the given one.
        /// </summary>
        public static int Other(int playerId)
        {
            return playerId == AgidelId ? AkashId : AgidelId;
        }

        /// <summary>
        /// Returns the next player's id in a fixed two-player rotation.
        /// </summary>
        public static int Next(int currentPlayerId)
        {
            return currentPlayerId == AgidelId ? AkashId : AgidelId;
        }

        /// <summary>
        /// Returns true if the id belongs to Agidel.
        /// </summary>
        public static bool IsAgidel(int playerId)
        {
            return playerId == AgidelId;
        }

        /// <summary>
        /// Returns true if the id belongs to Akash.
        /// </summary>
        public static bool IsAkash(int playerId)
        {
            return playerId == AkashId;
        }
    }
}
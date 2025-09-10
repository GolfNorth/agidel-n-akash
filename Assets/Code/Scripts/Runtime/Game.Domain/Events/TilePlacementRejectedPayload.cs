using Game.Domain.Core;

namespace Game.Domain.Events
{
    /// <summary>
    /// Payload for a rejected tile placement attempt.
    /// Allows Application/Presentation to show a reason to the user,
    /// log diagnostics, or trigger subtle feedback.
    /// </summary>
    public sealed class TilePlacementRejectedPayload
    {
        /// <summary>
        /// Prototype identifier that was attempted.
        /// </summary>
        public string ProtoId { get; set; }

        /// <summary>
        /// Player who attempted the placement.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Target board coordinate.
        /// </summary>
        public Coord Pos { get; set; }

        /// <summary>
        /// Human-readable reason (e.g., "Out of bounds", "Cell not empty").
        /// </summary>
        public string Reason { get; set; }
    }
}
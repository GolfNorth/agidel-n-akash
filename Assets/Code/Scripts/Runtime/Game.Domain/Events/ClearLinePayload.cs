using Game.Domain.Core;

namespace Game.Domain.Events
{
    /// <summary>
    /// Payload for clearing an entire row or column.
    /// Describes which axis and which line index was cleared.
    /// </summary>
    public sealed class ClearLinePayload
    {
        /// <summary>
        /// Axis that was cleared (row for Horizontal, column for Vertical).
        /// </summary>
        public Axis Axis { get; set; }

        /// <summary>
        /// Line index along the specified axis.
        /// </summary>
        public int Index { get; set; }
    }
}
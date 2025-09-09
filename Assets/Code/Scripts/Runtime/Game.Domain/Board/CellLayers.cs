using System.Collections.Generic;

namespace Game.Domain.Board
{
    /// <summary>
    /// Layered content of a single cell: base tile, overlays, and markers (flags).
    /// </summary>
    public sealed class CellLayers
    {
        public string Base = Core.Tags.None;
        public HashSet<string> Overlays { get; } = new();
        public HashSet<string> Markers { get; } = new();
    }
}
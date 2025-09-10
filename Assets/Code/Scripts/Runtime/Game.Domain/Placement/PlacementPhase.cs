namespace Game.Domain.Placement
{
    /// <summary>
    /// Execution phase that orders placement rules and allows cheap early-outs.
    /// </summary>
    public enum PlacementPhase
    {
        /// <summary>
        /// Board-agnostic or O(1) checks (e.g., resources, ownership).
        /// </summary>
        Early = 0,

        /// <summary>
        /// Local cell checks and constant-time reads (e.g., in-bounds, empty cell).
        /// </summary>
        Cell = 1,

        /// <summary>
        /// Neighborhood checks (adjacency, short local scans).
        /// </summary>
        Neighborhood = 2,

        /// <summary>
        /// Heavy or global checks (paths, global counts, multi-tile constraints).
        /// </summary>
        Late = 3
    }
}
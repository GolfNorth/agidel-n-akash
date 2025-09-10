namespace Game.Domain.Placement
{
    /// <summary>
    /// Single-responsibility rule for validating tile placement.
    /// </summary>
    public interface ITilePlacementRule
    {
        /// <summary>
        /// Phase used to order evaluation and enable early-outs.
        /// </summary>
        PlacementPhase Phase { get; }

        /// <summary>
        /// Returns true if the rule allows placement in the given context.
        /// On failure, returns false and provides a short human-readable reason.
        /// </summary>
        bool CanPlace(in PlacementCtx ctx, out string reason);
    }
}
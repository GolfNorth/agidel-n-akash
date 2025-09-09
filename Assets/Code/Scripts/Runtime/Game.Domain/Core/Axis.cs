namespace Game.Domain.Core
{
    /// <summary>
    /// Axis for line-oriented operations on the board (rows or columns).
    /// This is invariant under vertical UI flips; only the line index mapping changes.
    /// </summary>
    public enum Axis
    {
        /// <summary>
        /// Horizontal axis (operate on a row; Y is fixed, X varies).
        /// </summary>
        Horizontal = 0,

        /// <summary>
        /// Vertical axis (operate on a column; X is fixed, Y varies).
        /// </summary>
        Vertical = 1
    }
}
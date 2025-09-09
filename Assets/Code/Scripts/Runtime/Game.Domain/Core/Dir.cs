namespace Game.Domain.Core
{
    /// <summary>
    /// Cardinal directions in the canonical domain space (X to the right, Y down).
    /// </summary>
    public enum Dir
    {
        /// <summary>
        /// North / up (delta: 0, -1).
        /// </summary>
        N = 0,

        /// <summary>
        /// East / right (delta: +1, 0).
        /// </summary>
        E = 1,

        /// <summary>
        /// South / down (delta: 0, +1).
        /// </summary>
        S = 2,

        /// <summary>
        /// West / left (delta: -1, 0).
        /// </summary>
        W = 3
    }
}
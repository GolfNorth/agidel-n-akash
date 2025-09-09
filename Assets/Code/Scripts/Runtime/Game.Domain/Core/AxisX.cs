namespace Game.Domain.Core
{
    /// <summary>
    /// Helper methods for working with <see cref="Axis"/>.
    /// </summary>
    public static class AxisX
    {
        /// <summary>
        /// Returns <c>true</c> if the axis is horizontal.
        /// </summary>
        public static bool IsHorizontal(this Axis a)
        {
            return a == Axis.Horizontal;
        }

        /// <summary>
        /// Returns <c>true</c> if the axis is vertical.
        /// </summary>
        public static bool IsVertical(this Axis a)
        {
            return a == Axis.Vertical;
        }
    }
}
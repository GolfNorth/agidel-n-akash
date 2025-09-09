using System.Collections.Generic;
using Game.Domain.Core;

namespace Game.Domain.Utils
{
    /// <summary>
    /// Common coordinate selection patterns that are aware of board bounds.
    /// </summary>
    public static class Selectors
    {
        /// <summary>
        /// Returns 4 orthogonal neighbors (N, E, S, W) clipped to board bounds.
        /// </summary>
        public static IEnumerable<Coord> Neighbors4(Coord c, int width, int height)
        {
            foreach (var d in CoordX.D4)
            {
                var n = c + d;

                if (n is { X: >= 0, Y: >= 0 } && n.X < width && n.Y < height)
                    yield return n;
            }
        }

        /// <summary>
        /// Returns 8 neighbors (orthogonal + diagonal) clipped to board bounds.
        /// </summary>
        public static IEnumerable<Coord> Neighbors8(Coord c, int width, int height)
        {
            foreach (var d in CoordX.D8)
            {
                var n = c + d;

                if (n is { X: >= 0, Y: >= 0 } && n.X < width && n.Y < height)
                    yield return n;
            }
        }

        /// <summary>
        /// All coordinates of a line (row or column), inclusive.
        /// </summary>
        public static IEnumerable<Coord> Line(int index, Axis axis, int width, int height)
        {
            if (axis == Axis.Horizontal)
                for (var x = 0; x < width; x++)
                    yield return new Coord(x, index);
            else
                for (var y = 0; y < height; y++)
                    yield return new Coord(index, y);
        }

        /// <summary>
        /// Square neighborhood of radius r clipped to bounds (includes center).
        /// </summary>
        public static IEnumerable<Coord> InRadius(Coord c, int r, int width, int height)
        {
            for (var dy = -r; dy <= r; dy++)
            for (var dx = -r; dx <= r; dx++)
            {
                var n = new Coord(c.X + dx, c.Y + dy);

                if (n is { X: >= 0, Y: >= 0 } && n.X < width && n.Y < height)
                    yield return n;
            }
        }
    }
}
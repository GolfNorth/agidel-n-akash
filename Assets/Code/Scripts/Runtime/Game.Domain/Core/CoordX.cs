using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Game.Domain.Core
{
    /// <summary>
    /// Utilities and extra helpers for <see cref="Coord"/>.
    /// </summary>
    public static class CoordX
    {
        /// <summary>
        /// Returns (dx, dy) for a given cardinal direction.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int dx, int dy) Delta(Dir d)
        {
            return d switch
            {
                Dir.N => (0, -1),
                Dir.E => (1, 0),
                Dir.S => (0, 1),
                Dir.W => (-1, 0),
            };
        }

        /// <summary>
        /// Returns a new coordinate translated by (dx, dy).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Coord Offset(Coord c, int dx, int dy)
        {
            return new Coord(c.X + dx, c.Y + dy);
        }

        /// <summary>
        /// Manhattan (L1) distance between two coordinates.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Manhattan(Coord a, Coord b)
        {
            return Math.Abs(a.X - b.X) + System.Math.Abs(a.Y - b.Y);
        }

        /// <summary>
        /// Converts a 2D coordinate to a flat row-major index. No bounds checks.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToIndex(Coord c, int width)
        {
            return c.Y * width + c.X;
        }

        /// <summary>
        /// Converts a flat row-major index to a 2D coordinate. No bounds checks.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Coord FromIndex(int index, int width)
        {
            return new Coord(index % width, index / width);
        }

        /// <summary>
        /// Enumerates four orthogonal neighbors (N, E, S, W). Order: up, right, down, left.
        /// </summary>
        public static IEnumerable<Coord> Neighbors4(Coord c)
        {
            yield return new Coord(c.X, c.Y - 1);
            yield return new Coord(c.X + 1, c.Y);
            yield return new Coord(c.X, c.Y + 1);
            yield return new Coord(c.X - 1, c.Y);
        }

        /// <summary>
        /// Enumerates eight neighbors (4 orthogonal + 4 diagonal).
        /// Order: N, NE, E, SE, S, SW, W, NW.
        /// </summary>
        public static IEnumerable<Coord> Neighbors8(Coord c)
        {
            yield return new Coord(c.X, c.Y - 1);
            yield return new Coord(c.X + 1, c.Y - 1);
            yield return new Coord(c.X + 1, c.Y);
            yield return new Coord(c.X + 1, c.Y + 1);
            yield return new Coord(c.X, c.Y + 1);
            yield return new Coord(c.X - 1, c.Y + 1);
            yield return new Coord(c.X - 1, c.Y);
            yield return new Coord(c.X - 1, c.Y - 1);
        }

        /// <summary>
        /// Canonical 4-direction deltas (N, E, S, W). Useful to avoid per-frame allocations.
        /// </summary>
        public static readonly Coord[] D4 =
        {
            new Coord(0, -1),
            new Coord(1, 0),
            new Coord(0, 1),
            new Coord(-1, 0),
        };

        /// <summary>
        /// Canonical 8-direction deltas (N, NE, E, SE, S, SW, W, NW).
        /// </summary>
        public static readonly Coord[] D8 =
        {
            new Coord(0, -1),
            new Coord(1, -1),
            new Coord(1, 0),
            new Coord(1, 1),
            new Coord(0, 1),
            new Coord(-1, 1),
            new Coord(-1, 0),
            new Coord(-1, -1),
        };
    }
}
using System;

namespace Game.Domain.Core
{
    /// <summary>
    /// Helper methods for working with <see cref="Dir"/>.
    /// </summary>
    public static class DirX
    {
        /// <summary>
        /// Returns the opposite (reversed) direction (N&lt;-&gt;S, E&lt;-&gt;W).
        /// </summary>
        public static Dir Opposite(this Dir d)
        {
            return d switch
            {
                Dir.N => Dir.S,
                Dir.S => Dir.N,
                Dir.E => Dir.W,
                Dir.W => Dir.E,
                _ => throw new ArgumentOutOfRangeException(nameof(d), d, "Unsupported direction")
            };
        }

        /// <summary>
        /// Converts a direction to its integer coordinate delta (dx, dy).
        /// </summary>
        public static (int dx, int dy) ToDelta(this Dir d)
        {
            return d switch
            {
                Dir.N => (0, -1),
                Dir.E => (1, 0),
                Dir.S => (0, 1),
                Dir.W => (-1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(d), d, "Unsupported direction")
            };
        }

        /// <summary>
        /// Rotates a direction clockwise by 90 degrees.
        /// </summary>
        public static Dir RotCW(this Dir d)
        {
            return d switch
            {
                Dir.N => Dir.E,
                Dir.E => Dir.S,
                Dir.S => Dir.W,
                Dir.W => Dir.N,
                _ => throw new ArgumentOutOfRangeException(nameof(d), d, "Unsupported direction")
            };
        }

        /// <summary>
        /// Rotates a direction counter-clockwise by 90 degrees.
        /// </summary>
        public static Dir RotCCW(this Dir d)
        {
            return d switch
            {
                Dir.N => Dir.W,
                Dir.W => Dir.S,
                Dir.S => Dir.E,
                Dir.E => Dir.N,
                _ => throw new ArgumentOutOfRangeException(nameof(d), d, "Unsupported direction")
            };
        }
    }
}
namespace Game.Domain.Core
{
    /// <summary>
    /// Immutable integer grid coordinate (X right, Y down).
    /// </summary>
    public readonly struct Coord : System.IEquatable<Coord>
    {
        /// <summary>
        /// Zero-based X (column index).
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Zero-based Y (row index).
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Creates a new <see cref="Coord"/>.
        /// </summary>
        public Coord(int x, int y) { X = x; Y = y; }

        /// <inheritdoc />
        public bool Equals(Coord other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Coord c && Equals(c);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (X * 397) ^ Y;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        public static bool operator ==(Coord a, Coord b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        public static bool operator !=(Coord a, Coord b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Component-wise addition.
        /// </summary>
        public static Coord operator +(Coord a, Coord b)
        {
            return new Coord(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Component-wise subtraction.
        /// </summary>
        public static Coord operator -(Coord a, Coord b)
        {
            return new Coord(a.X - b.X, a.Y - b.Y);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
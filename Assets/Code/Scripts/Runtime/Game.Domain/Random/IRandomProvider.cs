using System;

namespace Game.Domain.Random
{
    /// <summary>
    /// Abstraction for a deterministic, cross-platform random number generator used by the game domain
    /// </summary>
    public interface IRandomProvider
    {
        /// <summary>
        /// Returns a non-negative random 31-bit integer in the range [0, 2^31).
        /// </summary>
        int Next();

        /// <summary>
        /// Returns a uniform integer in the half-open interval [minInclusive, maxExclusive).
        /// Uses rejection sampling to avoid modulo bias.
        /// </summary>
        /// <param name="minInclusive">Lower bound (inclusive).</param>
        /// <param name="maxExclusive">Upper bound (exclusive).</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.
        /// </exception>
        int Range(int minInclusive, int maxExclusive);

        /// <summary>
        /// Returns a uniform double in the half-open interval [0, 1).
        /// </summary>
        double Value01();

        /// <summary>
        /// Shuffles the specified array in-place using the Fisher–Yates algorithm.
        /// </summary>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <param name="array">Array to be shuffled. If null, the method does nothing.</param>
        void Shuffle<T>(T[] array);
    }
}
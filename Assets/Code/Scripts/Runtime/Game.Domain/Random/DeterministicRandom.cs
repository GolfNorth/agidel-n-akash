using System;

namespace Game.Domain.Random
{
    /// <summary>
    /// Deterministic random number generator based on xorshift128+ with 128-bit state.
    /// Provides reproducible sequences for simulations, replays, and testing.
    /// </summary>
    /// <remarks>
    /// References:
    /// - Sebastiano Vigna, "An experimental exploration of Marsaglia's xorshift generators,
    ///   scrambled", 2014.
    /// - SplitMix64 seeding: Steele et al.
    /// 
    /// The generator maintains 128-bit state and produces 64-bit outputs.
    /// Public methods expose typical helpers for ints, ranges, doubles, and shuffling.
    /// </remarks>
    public sealed class DeterministicRandom
    {
        // Internal 128-bit state (two 64-bit unsigned integers).
        private ulong _s0;
        private ulong _s1;

        /// <summary>
        /// Initializes a new instance of <see cref="DeterministicRandom"/> using a 64-bit seed.
        /// </summary>
        /// <param name="seed">Arbitrary 64-bit seed.</param>
        public DeterministicRandom(ulong seed)
        {
            // Seed using SplitMix64 to avoid poor states (e.g., all-zero).
            var sm = new SplitMix64(seed);

            _s0 = sm.Next();
            _s1 = sm.Next();

            if (_s0 == 0 && _s1 == 0)
                _s1 = 0x9E3779B97F4A7C15UL; // ensure non-zero state
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DeterministicRandom"/> using two 64-bit seeds.
        /// </summary>
        /// <param name="seed0">First 64-bit seed.</param>
        /// <param name="seed1">Second 64-bit seed.</param>
        public DeterministicRandom(ulong seed0, ulong seed1)
        {
            _s0 = seed0;
            _s1 = seed1;

            if (_s0 == 0 && _s1 == 0)
                _s1 = 0x9E3779B97F4A7C15UL;
        }

        /// <inheritdoc cref="IRandomProvider.Next" />
        public int Next()
        {
            // Return 31 non-negative bits similar to System.Random.Next().
            // Take the top 31 bits from a 64-bit output.
            return (int)(NextUInt64() >> 33);
        }

        /// <inheritdoc cref="IRandomProvider.Range" />
        public int Range(int minInclusive, int maxExclusive)
        {
            if (minInclusive >= maxExclusive)
                throw new ArgumentException("minInclusive must be < maxExclusive");

            var range = (uint)(maxExclusive - minInclusive);

            // Rejection sampling to avoid modulo bias:
            // draw 32 random bits, reject if below threshold.
            // threshold = 2^32 % range
            var threshold = (uint)(0x1_0000_0000UL % range);
            uint r;

            do
            {
                r = NextUInt32();
            } while (r < threshold);

            return (int)(minInclusive + (r % range));
        }

        /// <inheritdoc cref="IRandomProvider.Value01" />
        public double Value01()
        {
            // Construct a double in [0,1) from the top 53 bits of a 64-bit random.
            // 53-bit precision is the mantissa width of IEEE 754 double.
            ulong u = NextUInt64();
            const double inv = 1.0 / (1UL << 53);
            return (double)(u >> 11) * inv;
        }

        /// <inheritdoc cref="IRandomProvider.Shuffle" />
        public void Shuffle<T>(T[] array)
        {
            if (array == null)
                return;
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Range(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        /// <summary>
        /// Returns a uniformly distributed boolean.
        /// </summary>
        public bool NextBool()
        {
            return (NextUInt64() & 1UL) != 0;
        }

        /// <summary>
        /// Returns a uniformly distributed 32-bit unsigned integer.
        /// </summary>
        public uint NextUInt32()
        {
            return (uint)(NextUInt64() & 0xFFFF_FFFFu);
        }

        /// <summary>
        /// Returns a uniformly distributed 64-bit unsigned integer.
        /// </summary>
        public ulong NextUInt64()
        {
            // xorshift128+ core step
            var s1 = _s0;
            var s0 = _s1;
            _s0 = s0;
            s1 ^= s1 << 23;
            _s1 = s1 ^ s0 ^ (s1 >> 17) ^ (s0 >> 26);
            return _s1 + s0;
        }

        /// <summary>
        /// Gets the current internal state (for reproducible save/load, MCTS, replays).
        /// </summary>
        public (ulong s0, ulong s1) GetState()
        {
            return (_s0, _s1);
        }

        /// <summary>
        /// Sets the internal state. If both words are zero, a non-zero constant is injected.
        /// </summary>
        public void SetState(ulong s0, ulong s1)
        {
            _s0 = s0;
            _s1 = s1;
            if (_s0 == 0 && _s1 == 0)
                _s1 = 0x9E3779B97F4A7C15UL;
        }

        /// <summary>
        /// Creates a forked generator that is deterministically derived from the current state and the provided salt.
        /// Useful for per-turn/per-entity streams while preserving reproducibility.
        /// </summary>
        /// <param name="salt">Arbitrary 64-bit salt.</param>
        public DeterministicRandom Fork(ulong salt)
        {
            var sm = new SplitMix64(_s0 ^ _s1 ^ salt);
            return new DeterministicRandom(sm.Next(), sm.Next());
        }

        #region SplitMix64 seeding

        /// <summary>
        /// SplitMix64 seeding helper. Not intended for direct use outside this class.
        /// </summary>
        private struct SplitMix64
        {
            private ulong _x;

            public SplitMix64(ulong seed)
            {
                _x = seed;
            }

            /// <summary>
            /// Generates the next 64-bit value in the SplitMix64 sequence.
            /// </summary>
            public ulong Next()
            {
                var z = _x += 0x9E3779B97F4A7C15UL;
                z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
                z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
                return z ^ (z >> 31);
            }
        }

        #endregion
    }
}
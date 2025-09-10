using System.Collections.Generic;

namespace Game.Domain.Utils
{
    /// <summary>
    /// Simple pooled collections to reduce GC allocations in hot paths (simulation/ML).
    /// This is not thread-safe and should only be used inside one simulation context.
    /// </summary>
    public static class Collections
    {
        private static readonly Stack<HashSet<Core.Coord>> _hashSetPool = new();
        private static readonly Stack<List<Core.Coord>> _listPool = new();

        /// <summary>
        /// Rents a temporary <see cref="HashSet{Coord}"/> from the pool.
        /// Caller must return it with <see cref="Return"/>.
        /// </summary>
        public static HashSet<Core.Coord> RentHashSet()
        {
            return _hashSetPool.Count > 0 ? _hashSetPool.Pop() : new HashSet<Core.Coord>();
        }

        /// <summary>
        /// Rents a temporary <see cref="List{Coord}"/> from the pool.
        /// Caller must return it with <see cref="Return"/>.
        /// </summary>
        public static List<Core.Coord> RentList()
        {
            return _listPool.Count > 0 ? _listPool.Pop() : new List<Core.Coord>();
        }

        /// <summary>
        /// Returns a collection to the pool after clearing it.
        /// </summary>
        public static void Return(HashSet<Core.Coord> set)
        {
            set.Clear();
            _hashSetPool.Push(set);
        }

        /// <summary>
        /// Returns a collection to the pool after clearing it.
        /// </summary>
        public static void Return(List<Core.Coord> list)
        {
            list.Clear();
            _listPool.Push(list);
        }
    }
}
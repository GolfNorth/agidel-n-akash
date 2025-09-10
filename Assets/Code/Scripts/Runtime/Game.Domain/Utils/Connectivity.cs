using System;
using System.Collections.Generic;
using Game.Domain.Board;
using Game.Domain.Core;

namespace Game.Domain.Utils
{
    /// <summary>
    /// Generic connectivity helpers over the board grid.
    /// </summary>
    public static class Connectivity
    {
        /// <summary>
        /// True if there exists a path from the top edge (y==0) to the bottom edge (y==height-1).
        /// </summary>
        public static bool ExistsTopToBottomPath(
            BoardState board,
            Func<Coord, bool> isOpen,
            Func<Coord, Coord, bool> canTraverse = null,
            bool orthogonalOnly = true)
        {
            return ExistsEdgeToOppositeEdge(
                board,
                isOpen,
                canTraverse,
                orthogonalOnly,
                seedEdge: (w, h, emit) =>
                {
                    for (var x = 0; x < w; x++)
                    {
                        emit(new Coord(x, 0));
                    }
                },
                reachedOpposite: (c, w, h) => c.Y == h - 1
            );
        }

        /// <summary>
        /// True if there exists a path from the left edge (x==0) to the right edge (x==width-1).
        /// </summary>
        public static bool ExistsLeftToRightPath(
            BoardState board,
            Func<Coord, bool> isOpen,
            Func<Coord, Coord, bool> canTraverse = null,
            bool orthogonalOnly = true)
        {
            return ExistsEdgeToOppositeEdge(
                board,
                isOpen,
                canTraverse,
                orthogonalOnly,
                seedEdge: (w, h, emit) =>
                {
                    for (var y = 0; y < h; y++)
                    {
                        emit(new Coord(0, y));
                    }
                },
                reachedOpposite: (c, w, h) => c.X == w - 1
            );
        }

        /// <summary>
        /// Core BFS used by the public helpers. Seeds frontier from one edge and
        /// checks reachability of the opposite edge. All content-specific logic is
        /// delegated to <paramref name="isOpen"/> and <paramref name="canTraverse"/>.
        /// </summary>
        private static bool ExistsEdgeToOppositeEdge(
            BoardState board,
            Func<Coord, bool> isOpen,
            Func<Coord, Coord, bool> canTraverse,
            bool orthogonalOnly,
            Action<int, int, Action<Coord>> seedEdge,
            Func<Coord, int, int, bool> reachedOpposite)
        {
            var w = board.Width;
            var h = board.Height;

            var seen = new bool[w, h];
            var q = new Queue<Coord>();

            // Seed from the selected edge.
            seedEdge(w, h, c =>
            {
                if (InBounds(c, w, h) && isOpen(c))
                {
                    seen[c.X, c.Y] = true;
                    q.Enqueue(c);
                }
            });

            var dirs = orthogonalOnly ? CoordX.D4 : CoordX.D8;

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                if (reachedOpposite(cur, w, h))
                {
                    return true;
                }

                foreach (var d in dirs)
                {
                    var nxt = new Coord(cur.X + d.X, cur.Y + d.Y);

                    if (!InBounds(nxt, w, h))
                    {
                        continue;
                    }

                    if (seen[nxt.X, nxt.Y])
                    {
                        continue;
                    }

                    if (!isOpen(nxt))
                    {
                        continue;
                    }

                    if (canTraverse != null && !canTraverse(cur, nxt))
                    {
                        continue;
                    }

                    seen[nxt.X, nxt.Y] = true;
                    q.Enqueue(nxt);
                }
            }

            return false;
        }

        /// <summary>
        /// Bounds check helper to keep the hot loop tidy.
        /// </summary>
        private static bool InBounds(Coord c, int w, int h)
        {
            return c is { X: >= 0, Y: >= 0 } && c.X < w && c.Y < h;
        }
    }
}
using System.Collections.Generic;
using Game.Domain.Board;
using Game.Domain.Core;

namespace Game.Domain.Utils
{
    /// <summary>
    /// Simple BFS that checks whether there exists a top-to-bottom path of River base tiles.
    /// Flow blockers and overlays are ignored in this minimal version.
    /// </summary>
    public static class Pathfinding
    {
        /// <summary>
        /// Returns true if there is a connected component of river tiles that touches both the top row (y==0)
        /// and the bottom row (y==height-1), connected orthogonally.
        /// </summary>
        public static bool ExistsTopToBottomRiverPath(BoardState board)
        {
            var q = new Queue<Coord>();
            var seen = new bool[board.Width, board.Height];

            // Seed BFS with all river tiles on the top row.
            for (var x = 0; x < board.Width; x++)
            {
                var c = new Coord(x, 0);

                if (board.Get(c).Base != Tags.River)
                    continue;

                q.Enqueue(c);

                seen[x, 0] = true;
            }

            var dirs = new[] { new Coord(0, -1), new Coord(1, 0), new Coord(0, 1), new Coord(-1, 0) };

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                if (cur.Y == board.Height - 1)
                    return true;

                foreach (var d in dirs)
                {
                    var nx = cur.X + d.X;
                    var ny = cur.Y + d.Y;
                    var n = new Coord(nx, ny);

                    if (!board.InBounds(n) || seen[nx, ny])
                        continue;

                    if (board.Get(n).Base != Tags.River)
                        continue;

                    seen[nx, ny] = true;

                    q.Enqueue(n);
                }
            }

            return false;
        }
    }
}
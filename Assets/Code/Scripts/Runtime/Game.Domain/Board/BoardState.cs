using Game.Domain.Core;

namespace Game.Domain.Board
{
    /// <summary>
    /// 2D grid with layered cell content.
    /// Holds <see cref="CellLayers"/> per cell and provides minimal mutators.
    /// </summary>
    public sealed class BoardState
    {
        /// <summary>
        /// Width of the board.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Height of the board.
        /// </summary>
        public int Height { get; private set; }

        private readonly CellLayers[,] _cells;

        /// <summary>
        /// Creates a new board of the specified size filled with empty cells.
        /// </summary>
        public BoardState(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new CellLayers[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _cells[x, y] = new CellLayers { Base = Tags.None };
                }
            }
        }

        /// <summary>
        /// Checks whether the given coordinate lies inside the board bounds.
        /// </summary>
        public bool InBounds(Coord c)
        {
            return c.X >= 0 && c.Y >= 0 && c.X < Width && c.Y < Height;
        }

        /// <summary>
        /// Gets a mutable reference to the cell at the specified coordinate.
        /// </summary>
        public CellLayers Get(Coord c)
        {
            return _cells[c.X, c.Y];
        }

        /// <summary>
        /// Sets the base tag at the given coordinate.
        /// </summary>
        public void SetBase(Coord c, string baseTag)
        {
            _cells[c.X, c.Y].Base = baseTag;
        }

        /// <summary>
        /// Creates a deep clone of the board content.
        /// </summary>
        public BoardState Clone()
        {
            var clone = new BoardState(Width, Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var src = _cells[x, y];
                    var dst = clone._cells[x, y];

                    dst.Base = src.Base;

                    dst.Overlays.Clear();
                    foreach (var t in src.Overlays)
                    {
                        dst.Overlays.Add(t);
                    }

                    dst.Markers.Clear();
                    foreach (var m in src.Markers)
                    {
                        dst.Markers.Add(m);
                    }
                }
            }

            return clone;
        }

        /// <summary>
        /// Clears a full row or column.
        /// </summary>
        /// <param name="index">
        /// For <see cref="Axis.Horizontal"/> this is the row (Y) index.
        /// For <see cref="Axis.Vertical"/> this is the column (X) index.
        /// </param>
        /// <param name="axis">
        /// Specifies whether to clear a row or a column.
        /// </param>
        public void ClearLine(int index, Axis axis)
        {
            if (axis == Axis.Horizontal)
            {
                if (index < 0 || index >= Height)
                {
                    throw new DomainException($"ClearLine: row index out of range: {index} (0..{Height - 1})");
                }
            }
            else
            {
                if (index < 0 || index >= Width)
                {
                    throw new DomainException($"ClearLine: column index out of range: {index} (0..{Width - 1})");
                }
            }

            if (axis == Axis.Horizontal)
            {
                for (int x = 0; x < Width; x++)
                {
                    var c = new Coord(x, index);
                    var cell = Get(c);
                    cell.Base = Tags.None;
                    cell.Overlays.Clear();
                    cell.Markers.Clear();
                }
            }
            else
            {
                for (int y = 0; y < Height; y++)
                {
                    var c = new Coord(index, y);
                    var cell = Get(c);
                    cell.Base = Tags.None;
                    cell.Overlays.Clear();
                    cell.Markers.Clear();
                }
            }
        }
    }
}
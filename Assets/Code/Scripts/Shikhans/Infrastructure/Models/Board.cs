using System.Collections;
using System.Collections.Generic;
using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Models
{
    /// <summary>
    /// Игровая доска
    /// </summary>
    public sealed class Board : IBoard, INeighborProvider
    {
        /// <summary>
        /// Коллекция ячеек игровой доски
        /// </summary>
        private readonly ICell[] _cells;

        public int Width { get; }
        public int Height { get; }

        public ICell this[int x, int y] => GetCell(x, y);

        public Board(int width, int height, ICellFactory cellFactory)
        {
            Width = width;
            Height = height;
            _cells = new ICell[width * height];

            InitializeCells(cellFactory);
        }

        private void InitializeCells(ICellFactory cellFactory)
        {
            for (var i = 0; i < _cells.Length; i++)
            {
                GetCoordinates(i, out var x, out var y);

                _cells[i] = cellFactory.CreateCell(CellType.None, x, y);
            }
        }

        public ICell GetCell(int x, int y)
        {
            if (!IsWithinBounds(x, y))
                return null;

            var index = GetIndex(x, y);

            return _cells[index];
        }

        public bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        #region Enumerator

        public IEnumerator<ICell> GetEnumerator()
        {
            return ((IEnumerable<ICell>)_cells).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Neighbores

        public ICell GetNeighbor(int x, int y, Direction direction)
        {
            var cell = GetCell(x, y);

            return GetNeighbor(cell, direction);
        }

        public ICell GetNeighbor(ICell cell, Direction direction)
        {
            var newX = cell.X;
            var newY = cell.Y;

            switch (direction)
            {
                case Direction.Top:
                    newX--;
                    break;
                case Direction.TopRight:
                    newX--;
                    newY++;
                    break;
                case Direction.Right:
                    newY++;
                    break;
                case Direction.BottomRight:
                    newX++;
                    newY++;
                    break;
                case Direction.Bottom:
                    newX++;
                    break;
                case Direction.BottomLeft:
                    newX++;
                    newY--;
                    break;
                case Direction.Left:
                    newY--;
                    break;
                case Direction.TopLeft:
                    newX--;
                    newY--;
                    break;
            }

            return GetCell(newX, newY);
        }

        #endregion

        #region Coordinates

        /// <summary>
        /// Возвращает координаты для заданного индекса
        /// </summary>
        private void GetCoordinates(int index, out int x, out int y)
        {
            x = index % Width;
            y = index / Width;
        }

        /// <summary>
        /// Возвращает индекс для заданных координат
        /// </summary>
        private int GetIndex(int x, int y)
        {
            return y * Width + x;
        }

        #endregion
    }
}
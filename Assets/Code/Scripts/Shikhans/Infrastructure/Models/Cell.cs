using System;
using System.Collections.Generic;
using System.Linq;
using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Models
{
    /// <summary>
    /// Ячейка игрового поля
    /// </summary>
    public sealed class Cell : ICell
    {
        private readonly INeighborProvider _neighborProvider;
        public int X { get; }
        public int Y { get; }
        public CellType Type { get; set; }
        public ManaSymbol Symbols { get; set; }
        public Stack<ICard> Cards { get; }

        public Cell(CellType type, int x, int y, INeighborProvider neighborProvider,
            ManaSymbol symbols = ManaSymbol.None)
        {
            X = x;
            Y = y;
            Type = type;
            Symbols = symbols;
            Cards = new Stack<ICard>();
            _neighborProvider = neighborProvider;
        }

        public ICell GetNeighbor(Direction direction)
        {
            return _neighborProvider.GetNeighbor(X, Y, direction);
        }

        public IEnumerable<ICell> GetNeighbors(IEnumerable<Direction> directions = null)
        {
            directions ??= Enum.GetValues(typeof(Direction)).Cast<Direction>();

            foreach (var direction in directions)
            {
                var neighbor = GetNeighbor(direction);

                if (neighbor != null)
                {
                    yield return neighbor;
                }
            }
        }
    }
}
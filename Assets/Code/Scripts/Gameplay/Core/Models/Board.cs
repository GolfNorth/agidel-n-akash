using System.Collections;
using System.Collections.Generic;

namespace Gameplay.Core
{
    /// <summary>
    /// Игровое поле
    /// </summary>
    public class Board : IEnumerable<Node>
    {
        /// <summary>
        /// Массив узлов поля
        /// </summary>
        private readonly Node[,] _nodes;

        /// <summary>
        /// Ширина поля
        /// </summary>
        public int Width => _nodes.GetUpperBound(0) + 1;

        /// <summary>
        /// Высота поля
        /// </summary>
        public int Height => _nodes.GetUpperBound(1) + 1;

        public Node this[int x, int y]
        {
            get
            {
                if (_nodes == null || x < 0 || x > Width || y < 0 || y > Height)
                    return null;

                return _nodes[x, y];
            }
        }

        /// <param name="width">Ширина поля</param>
        /// <param name="height">Высота поля</param>
        public Board(int width, int height)
        {
            _nodes = new Node[width, height];

            CreateNodes(width);
        }

        private void CreateNodes(int width)
        {
            for (var x = width; x >= 0; x--)
            {
                for (var y = width; y >= 0; y--)
                {
                    _nodes[x, y] = new Node(x, y)
                    {
                        Type = NodeType.None
                    };
                }
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return new BoardEnumerator(_nodes);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
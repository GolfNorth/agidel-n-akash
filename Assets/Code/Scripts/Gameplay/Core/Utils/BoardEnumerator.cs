using System;
using System.Collections;
using System.Collections.Generic;

namespace Gameplay.Core
{
    /// <summary>
    /// Перечислитель узлов поля
    /// </summary>
    public class BoardEnumerator : IEnumerator<Node>
    {
        /// <summary>
        /// Узлы игрового поля
        /// </summary>
        private Node[,] _nodes;

        /// <summary>
        /// Текущие значения x и y
        /// </summary>
        private int _x, _y = -1;

        object IEnumerator.Current => Current;

        public Node Current
        {
            get
            {
                try
                {
                    return _nodes[_x, _y];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public BoardEnumerator(Node[,] nodes)
        {
            _nodes = nodes;
        }

        public bool MoveNext()
        {
            _x++;

            if (_x > _nodes.GetUpperBound(0))
            {
                _x = 0;
                _y++;
            }

            return _y <= _nodes.GetUpperBound(1);
        }

        public void Reset()
        {
            _x = 0;
            _y = 0;
        }

        public void Dispose()
        {
            _nodes = null;
        }
    }
}
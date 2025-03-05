namespace Gameplay.Core
{
    /// <summary>
    /// Узел на игровом поле
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Тип узла
        /// </summary>
        private NodeType _type;

        /// <summary>
        /// Тип узла
        /// </summary>
        public NodeType Type
        {
            get => _type;
            internal set
            {
                if (_type == value)
                    return;

                var prevType = _type;
                _type = value;

                OnTypeChanged(prevType, _type);
            }
        }
        
        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get; }
        
        /// <summary>
        /// Координата X
        /// </summary>
        public int Y { get; }

        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Обработка изменения узла
        /// </summary>
        /// <param name="prevType">Предыдущий тип</param>
        /// <param name="newType">Новый тип</param>
        private void OnTypeChanged(NodeType prevType, NodeType newType)
        {
            // TODO Событие о смене типа или реакторный тип поля?
        }
    }
}
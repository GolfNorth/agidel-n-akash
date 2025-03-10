using System.Collections.Generic;
using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс ячейки на игровом поле
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Координата X ячейки на поле
        /// </summary>
        int X { get; }

        /// <summary>
        /// Координата Y ячейки на поле
        /// </summary>
        int Y { get; }

        /// <summary>
        /// Тип ячейки
        /// </summary>
        CellType Type { get; set; }

        /// <summary>
        /// Символы маны, связанные с ячейкой
        /// </summary>
        ManaSymbol Symbols { get; set; }

        /// <summary>
        /// Стек карт, размещённых на ячейке
        /// </summary>
        Stack<ICard> Cards { get; }

        /// <summary>
        /// Получает соседа ячейки по указанному направлению.
        /// </summary>
        /// <param name="direction">Направление, в котором искать соседа.</param>
        /// <returns>Соседняя ячейка или null, если соседа нет.</returns>
        ICell GetNeighbor(Direction direction);

        /// <summary>
        /// Получает всех соседей ячейки по указанным направлениям.
        /// </summary>
        /// <param name="directions">Список направлений для поиска соседей.</param>
        /// <returns>Перечисление соседних ячеек.</returns>
        IEnumerable<ICell> GetNeighbors(IEnumerable<Direction> directions = null);
    }
}
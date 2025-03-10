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
    }
}
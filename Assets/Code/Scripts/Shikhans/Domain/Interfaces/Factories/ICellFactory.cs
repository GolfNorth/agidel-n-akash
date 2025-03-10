using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Фабрика для создания ячеек
    /// </summary>
    public interface ICellFactory
    {
        /// <summary>
        /// Создаёт ячейку с указанными координатами и типом
        /// </summary>
        /// <param name="type">Тип ячейки</param>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>Созданная ячейка</returns>
        ICell CreateCell(CellType type, int x, int y);
    }
}
using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Провайдер предоставления соседних ячеек
    /// </summary>
    public interface INeighborProvider
    {
        /// <summary>
        /// Предоставляет соседнюю ячейку по заданному направлению для заданной координаты
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="direction">Направление</param>
        /// <returns>Соседняя ячейка</returns>
        ICell GetNeighbor(int x, int y, Direction direction);

        /// <summary>
        /// Предоставляет соседнюю ячейку по заданному направлению для заданной ячейки
        /// </summary>
        /// <param name="cell">Ячейка для поиска соседа</param>
        /// <param name="direction">Направление</param>
        /// <returns>Соседняя ячейка</returns>
        ICell GetNeighbor(ICell cell, Direction direction);
    }
}
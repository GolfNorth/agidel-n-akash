using System.Collections.Generic;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс, представляющий игровую доску
    /// </summary>
    public interface IBoard : IEnumerable<ICell>
    {
        /// <summary>
        /// Ширина доски
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Высота доски
        /// </summary>
        int Height { get; }
        
        /// <summary>
        /// Индексатор для доступа к ячейкам доски
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>Ячейка на указанных координатах</returns>
        ICell this[int x, int y] { get; }

        /// <summary>
        /// Получает ячейку по координатам
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>Ячейка на указанных координатах</returns>
        ICell GetCell(int x, int y);

        /// <summary>
        /// Проверяет, находятся ли координаты в пределах доски
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>True, если координаты допустимы, иначе False</returns>
        bool IsWithinBounds(int x, int y);
    }
}
namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс, представляющий размещение карты на ячейке.
    /// </summary>
    public interface IPlacement
    {
        /// <summary>
        /// Проверяет, можно ли разместить карту на указанной ячейке
        /// </summary>
        /// <param name="cell">Ячейка, на которую предполагается разместить карту</param>
        /// <param name="card">Карта, которую нужно разместить</param>
        /// <returns>True, если карту можно разместить, иначе False</returns>
        bool CanPlace(ICell cell, ICard card);

        /// <summary>
        /// Размещает карту на указанной ячейке
        /// </summary>
        /// <param name="cell">Ячейка, на которую размещается карта</param>
        /// <param name="card">Карта, которую нужно разместить</param>
        /// <returns>True, если карту удалось разместить, иначе False</returns>
        bool TryPlace(ICell cell, ICard card);
    }
}
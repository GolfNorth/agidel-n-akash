using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс игровой карты
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Тип карты
        /// </summary>
        CardType Type { get; }

        /// <summary>
        /// Стоимость применения карты
        /// </summary>
        int ManaCost { get; }

        /// <summary>
        /// Проверяет, можно ли разместить карту на указанной ячейке
        /// </summary>
        /// <param name="cell">Ячейка, на которую предполагается разместить карту</param>
        /// <returns>True, если карту можно разместить, иначе False</returns>
        bool CanPlace(ICell cell);

        /// <summary>
        /// Размещает карту на указанной ячейке
        /// </summary>
        /// <param name="cell">Ячейка, на которую размещается карта</param>
        /// <returns>True, если карту удалось разместить, иначе False</returns>
        bool TryPlace(ICell cell);
    }
}
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
    }
}
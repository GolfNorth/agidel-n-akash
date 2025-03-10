using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Фабрика для создания карт
    /// </summary>
    public interface ICardFactory
    {
        /// <summary>
        /// Создаёт карту указанного типа
        /// </summary>
        /// <param name="type">Тип карты</param>
        /// <returns>Созданная карта</returns>
        ICard CreateCard(CardType type);
    }
}
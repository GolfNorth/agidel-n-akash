using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Фабрика для создания объектов размещения карт
    /// </summary>
    public interface IPlacementFactory
    {
        /// <summary>
        /// Создаёт объект размещения для указанной карты
        /// </summary>
        /// <param name="cardType">Тип карты, для которой нужно создать размещение</param>
        /// <returns>Объект размещения</returns>
        IPlacement CreatePlacement(CardType cardType);
    }
}
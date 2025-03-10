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
        /// <param name="card">Карта, для которой нужно создать размещение</param>
        /// <returns>Объект размещения</returns>
        IPlacement CreatePlacement(ICard card);
    }
}
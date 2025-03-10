using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Services
{
    /// <summary>
    /// Сервис размещения карт на ячейки
    /// </summary>
    public sealed class PlacementService : IPlacementService
    {
        /// <summary>
        /// Фабрика для создания объектов размещения карт
        /// </summary>
        private readonly IPlacementFactory _placementFactory;

        public PlacementService(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }

        public bool CanPlaceCard(ICell cell, ICard card)
        {
            var placement = _placementFactory.CreatePlacement(card.Type);

            return placement.CanPlace(cell, card);
        }

        public bool TryPlaceCard(ICell cell, ICard card)
        {
            var placement = _placementFactory.CreatePlacement(card.Type);

            return placement.TryPlace(cell, card);
        }
    }
}
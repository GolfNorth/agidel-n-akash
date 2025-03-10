using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Placements
{
    /// <summary>
    /// Базовый класс размещения карты
    /// </summary>
    public abstract class BasePlacement : IPlacement
    {
        /// <summary>
        /// Текущая карта для размещения
        /// </summary>
        protected abstract CardType Type { get; }

        public bool CanPlace(ICell cell, ICard card)
        {
            if (card.Type != Type)
                return false;

            return CanPlaceImpl(cell, card);
        }

        public bool TryPlace(ICell cell, ICard card)
        {
            if (!CanPlace(cell, card))
                return false;

            PlaceImpl(cell, card);

            return true;
        }

        /// <summary>
        /// Проверяет, можно ли разместить карту на указанной ячейке
        /// </summary>
        /// <param name="cell">Ячейка, на которую предполагается разместить карту</param>
        /// <param name="card">Карта, которую нужно разместить</param>
        /// <returns>True, если карту можно разместить, иначе False</returns>
        protected abstract bool CanPlaceImpl(ICell cell, ICard card);

        /// <summary>
        /// Размещает карту на указанной ячейке
        /// </summary>
        /// <param name="cell">Ячейка, на которую размещается карта</param>
        /// <param name="card">Карта, которую нужно разместить</param>
        protected abstract void PlaceImpl(ICell cell, ICard card);
    }
}
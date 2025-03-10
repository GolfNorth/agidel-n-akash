using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Placements
{
    /// <summary>
    /// Размещение карты воды
    /// </summary>
    public class WaterPlacement : BasePlacement
    {
        protected override CardType Type => CardType.Water;

        protected override bool CanPlaceImpl(ICell cell, ICard card)
        {
            // TODO
            
            switch (cell.Type)
            {
                case CellType.None:
                    return true;
                case CellType.River:
                    break;
                case CellType.Quarry:
                    break;
                case CellType.MountainRiver:
                    break;
                case CellType.Stone:
                    break;
                case CellType.Dam:
                    break;
                case CellType.Rift:
                    break;
                case CellType.Fortress:
                    break;
                case CellType.Heart:
                    break;
                case CellType.Horse:
                    break;
                case CellType.Bird:
                    break;
                default:
                    return false;
            }

            return false;
        }

        protected override void PlaceImpl(ICell cell, ICard card)
        {
            cell.Cards.Push(card);
            cell.Type = CellType.River;
        }
    }
}
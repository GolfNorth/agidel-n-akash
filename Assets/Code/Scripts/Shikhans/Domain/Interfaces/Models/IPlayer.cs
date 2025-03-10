using System.Collections.Generic;
using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс игрока
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Тип игрока
        /// </summary>
        PlayerType Type { get; }

        /// <summary>
        /// Количество маны
        /// </summary>
        int Mana { get; set; }

        /// <summary>
        /// Карты игрока
        /// </summary>
        IList<ICard> Cards { get; }
    }
}
using System.Collections.Generic;
using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Models
{
    /// <summary>
    /// Объект игрока
    /// </summary>
    public sealed class Player : IPlayer
    {
        public PlayerType Type { get; }
        public int Mana { get; set; }
        public IList<ICard> Cards { get; }

        public Player(PlayerType type, IList<ICard> cards)
        {
            Type = type;
            Cards = cards;
            Mana = 0;
        }
    }
}
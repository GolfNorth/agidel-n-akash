using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Models
{
    /// <summary>
    /// Игровая карта
    /// </summary>
    public sealed class Card : ICard
    {
        public CardType Type { get; }
        public int ManaCost { get; }

        public Card(CardType type, int manaCost)
        {
            Type = type;
            ManaCost = manaCost;
        }
    }
}
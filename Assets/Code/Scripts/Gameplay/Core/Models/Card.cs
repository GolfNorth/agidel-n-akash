namespace Gameplay.Core
{
    /// <summary>
    /// Игровая карта у игрока
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Тип карты
        /// </summary>
        public CardType Type { get; }

        public Card(CardType type)
        {
            Type = type;
        }
    }
}
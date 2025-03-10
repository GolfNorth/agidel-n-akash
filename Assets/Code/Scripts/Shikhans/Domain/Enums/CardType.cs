namespace Shikhans.Domain.Enums
{
    /// <summary>
    /// Типы карт
    /// </summary>
    public enum CardType : byte
    {
        None = 0,

        /// <summary>
        /// Вода
        /// </summary>
        Water = 1,

        /// <summary>
        /// Каменоломня
        /// </summary>
        Quarry = 2,

        /// <summary>
        /// Бурный поток
        /// </summary>
        Stream = 3,

        /// <summary>
        /// Водоворот
        /// </summary>
        Whirlpool = 4,

        /// <summary>
        /// Великий поток
        /// </summary>
        Flood = 5,

        /// <summary>
        /// Камень
        /// </summary>
        Stone = 11,

        /// <summary>
        /// Плотина
        /// </summary>
        Dam = 12,

        /// <summary>
        /// Землетресение
        /// </summary>
        Earthquake = 13,

        /// <summary>
        /// Разлом
        /// </summary>
        Rift = 14,

        /// <summary>
        /// Крепость-гора
        /// </summary>
        Fortress = 15,

        /// <summary>
        /// Сердце-гора
        /// </summary>
        Heart = 16,

        /// <summary>
        /// Лошадь-гора
        /// </summary>
        Horse = 17,

        /// <summary>
        /// Птица-гора
        /// </summary>
        Bird = 18,
    }
}
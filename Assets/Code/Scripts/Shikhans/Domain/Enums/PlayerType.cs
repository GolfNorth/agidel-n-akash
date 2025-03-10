namespace Shikhans.Domain.Enums
{
    /// <summary>
    /// Тип игрока
    /// </summary>
    public enum PlayerType : byte
    {
        /// <summary>
        /// Неопределенный
        /// </summary>
        None = 0,

        /// <summary>
        /// Агидель - маг воды
        /// </summary>
        Agidel = 1,

        /// <summary>
        /// Акаш - маг камня
        /// </summary>
        Akash = 2
    }
}
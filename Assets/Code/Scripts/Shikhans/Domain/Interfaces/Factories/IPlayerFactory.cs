using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Фабрика для создания игроков
    /// </summary>
    public interface IPlayerFactory
    {
        /// <summary>
        /// Создаёт нового игрока
        /// </summary>
        /// <param name="type">Тип игрока</param>
        /// <returns>Созданный игрок</returns>
        IPlayer CreatePlayer(PlayerType type);
    }
}
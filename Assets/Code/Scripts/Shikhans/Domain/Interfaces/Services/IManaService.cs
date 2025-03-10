using Shikhans.Domain.Enums;

namespace Shikhans.Domain.Interfaces
{
    /// <summary>
    /// Сервис для управления символами маны
    /// </summary>
    public interface IManaService
    {
        /// <summary>
        /// Устанавливает символы маны на ячейку
        /// </summary>
        /// <param name="cell">Ячейка, на которую устанавливаются символы</param>
        /// <param name="symbol">Символы маны, которые нужно установить</param>
        void SetManaSymbols(ICell cell, ManaSymbol symbol);

        /// <summary>
        /// Проверяет, есть ли на ячейке указанный символ маны
        /// </summary>
        /// <param name="cell">Ячейка для проверки</param>
        /// <param name="symbol">Символ маны для проверки</param>
        /// <returns>True, если символ присутствует, иначе False</returns>
        bool HasManaSymbol(ICell cell, ManaSymbol symbol);

        /// <summary>
        /// Проверяет, достаточно ли маны у игрока для выполнения действия
        /// </summary>
        /// <param name="player">Игрок, у которого проверяется мана</param>
        /// <param name="manaCost">Требуемое количество маны</param>
        /// <returns>True, если маны достаточно, иначе False</returns>
        bool CanSpendMana(IPlayer player, int manaCost);

        /// <summary>
        /// Списание маны у игрока
        /// </summary>
        /// <param name="player">Игрок, у которого списывается мана</param>
        /// <param name="manaCost">Количество маны для списания</param>
        void SpendMana(IPlayer player, int manaCost);

        /// <summary>
        /// Добавляет ману игроку
        /// </summary>
        /// <param name="player">Игрок, которому добавляется мана</param>
        /// <param name="manaAmount">Количество маны для добавления</param>
        void AddMana(IPlayer player, int manaAmount);
    }
}
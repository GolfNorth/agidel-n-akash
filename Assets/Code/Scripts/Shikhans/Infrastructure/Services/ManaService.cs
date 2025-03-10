using Shikhans.Domain.Enums;
using Shikhans.Domain.Interfaces;

namespace Shikhans.Infrastructure.Services
{
    /// <summary>
    /// Сервис для управления символами маны
    /// </summary>
    public class ManaService : IManaService
    {
        public void SetManaSymbols(ICell cell, ManaSymbol symbols)
        {
            cell.Symbols = symbols;
        }

        public bool HasManaSymbol(ICell cell, ManaSymbol symbol)
        {
            return cell.Symbols.HasFlag(symbol);
        }

        public bool CanSpendMana(IPlayer player, int manaCost)
        {
            return player.Mana >= manaCost;
        }

        public void SpendMana(IPlayer player, int manaCost)
        {
            player.Mana -= manaCost;
        }

        public void AddMana(IPlayer player, int manaAmount)
        {
            player.Mana += manaAmount;
        }
    }
}
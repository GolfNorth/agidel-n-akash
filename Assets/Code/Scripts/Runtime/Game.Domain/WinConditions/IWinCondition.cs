namespace Game.Domain.WinConditions
{
    /// <summary>
    /// Abstraction for a win condition check.
    /// Implementations examine the game state and decide if a player has won.
    /// </summary>
    public interface IWinCondition
    {
        /// <summary>
        /// Checks the game state and returns the winner id if this condition is satisfied.
        /// Returns null if the condition is not satisfied.
        /// Use -1 to indicate a draw if supported by the rule.
        /// </summary>
        int? Check(GameState state);
    }
}
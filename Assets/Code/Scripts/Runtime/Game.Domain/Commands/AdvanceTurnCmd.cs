using Game.Domain.Events;

namespace Game.Domain.Commands
{
    /// <summary>
    /// Advances the turn to the next player and emits a turn-advanced event.
    /// </summary>
    public sealed class AdvanceTurnCmd : ICommand
    {
        /// <summary>
        /// Applies the turn change and emits <see cref="GameEvent.TurnAdvanced"/>.
        /// </summary>
        public void Do(GameState state, IEventSink events)
        {
            state.NextPlayer();

            var payload = new TurnAdvancedPayload
            {
                Turn = state.Turn,
                CurrentPlayerId = state.CurrentPlayerId
            };

            events.Emit(GameEvent.TurnAdvanced, payload);
        }

        /// <summary>
        /// Reverts the turn change (goes back to the previous player).
        /// </summary>
        public void Undo(GameState state, IEventSink events)
        {
            state.RevertPlayer();

            var payload = new TurnAdvancedPayload
            {
                Turn = state.Turn,
                CurrentPlayerId = state.CurrentPlayerId
            };

            events.Emit(GameEvent.TurnAdvanced, payload);
        }

        /// <summary>
        /// Returns a presentation payload mirroring the current turn owner.
        /// </summary>
        public object ToPresentationPayload(GameState state)
        {
            return new TurnAdvancedPayload
            {
                Turn = state.Turn,
                CurrentPlayerId = state.CurrentPlayerId
            };
        }
    }
}
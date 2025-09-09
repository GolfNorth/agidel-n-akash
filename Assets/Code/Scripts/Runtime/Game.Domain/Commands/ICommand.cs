// Game.Domain/Commands/ICommand.cs
using Game.Domain.Events;

namespace Game.Domain.Commands
{
    /// <summary>
    /// Represents a single deterministic mutation of <see cref="GameState"/>.
    /// Commands are the only way the domain state is allowed to change.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Applies this command to the given <paramref name="state"/>.
        /// Must be deterministic and free of side effects outside of the state
        /// and the provided <paramref name="events"/> sink.
        /// </summary>
        /// <param name="state">The current game state to mutate.</param>
        /// <param name="events">Event sink used to emit domain events for observers.</param>
        void Do(GameState state, IEventSink events);

        /// <summary>
        /// Reverts the effects of this command on the given <paramref name="state"/>.
        /// This is optional; implementations may throw <see cref="System.NotSupportedException"/>
        /// if undo is not supported for a particular command.
        /// </summary>
        /// <param name="state">The game state to revert.</param>
        /// <param name="events">Event sink used to emit domain events for observers.</param>
        void Undo(GameState state, IEventSink events);

        /// <summary>
        /// Returns a lightweight payload describing what this command did,
        /// suitable for presentation/UI layers (e.g., animations).
        /// May return <c>null</c> if no payload is relevant.
        /// </summary>
        /// <param name="state">The state after execution, useful if payload depends on final values.</param>
        object ToPresentationPayload(GameState state);
    }
}
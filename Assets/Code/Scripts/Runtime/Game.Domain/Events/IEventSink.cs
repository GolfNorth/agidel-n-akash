namespace Game.Domain.Events
{
    /// <summary>
    /// Abstraction for publishing domain events to observers (application/presentation).
    /// Domain code only emits events, never subscribes to them directly.
    /// </summary>
    public interface IEventSink
    {
        /// <summary>
        /// Emits a domain event with an optional payload.
        /// Implementations may dispatch to an event bus, log, or directly call listeners.
        /// </summary>
        /// <param name="evt">The type of the event that occurred.</param>
        /// <param name="payload">Optional DTO with event details. May be <c>null</c>.</param>
        void Emit(GameEvent evt, object payload = null);
    }
}

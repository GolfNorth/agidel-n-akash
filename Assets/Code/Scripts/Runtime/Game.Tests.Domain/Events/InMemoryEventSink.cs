using System.Collections.Generic;
using Game.Domain.Events;

namespace Game.Tests.Domain.Events
{
    /// <summary>
    /// Collects emitted events for assertions in tests.
    /// </summary>
    public sealed class InMemoryEventSink : IEventSink
    {
        public readonly List<(GameEvent Evt, object Payload)> Items = new();

        public void Emit(GameEvent evt, object payload = null)
        {
            Items.Add((evt, payload));
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
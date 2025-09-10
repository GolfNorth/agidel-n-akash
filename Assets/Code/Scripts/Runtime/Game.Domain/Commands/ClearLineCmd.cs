using System.Collections.Generic;
using Game.Domain.Core;
using Game.Domain.Events;

namespace Game.Domain.Commands
{
    /// <summary>
    /// Clears an entire row or column by resetting base tags and removing overlays/markers.
    /// Emits <see cref="GameEvent.LineCleared"/> with <see cref="ClearLinePayload"/>.
    /// Keeps a snapshot to support undo.
    /// </summary>
    public sealed class ClearLineCmd : ICommand
    {
        private readonly Axis _axis;
        private readonly int _index;

        // Snapshot per cell along the cleared line, in order.
        private List<(Coord pos, string Base, string[] Overlays, string[] Markers)> _snapshot;

        /// <summary>
        /// Creates a command that clears a row or column specified by axis and index.
        /// </summary>
        public ClearLineCmd(Axis axis, int index)
        {
            _axis = axis;
            _index = index;
            _snapshot = null;
        }

        /// <summary>
        /// Clears the line and emits a LineCleared event.
        /// </summary>
        public void Do(GameState state, IEventSink events)
        {
            if (_axis == Axis.Horizontal && (_index < 0 || _index >= state.Board.Height))
            {
                throw new DomainException($"ClearLine: row index out of range: {_index}");
            }

            if (_axis == Axis.Vertical && (_index < 0 || _index >= state.Board.Width))
            {
                throw new DomainException($"ClearLine: column index out of range: {_index}");
            }


            var board = state.Board;
            _snapshot = new List<(Coord, string, string[], string[])>();

            if (_axis == Axis.Horizontal)
            {
                for (var x = 0; x < board.Width; x++)
                {
                    var c = new Coord(x, _index);
                    var cell = board.Get(c);

                    _snapshot.Add((c, cell.Base, ToArray(cell.Overlays), ToArray(cell.Markers)));

                    cell.Base = Tags.None;
                    cell.Overlays.Clear();
                    cell.Markers.Clear();
                }
            }
            else
            {
                for (var y = 0; y < board.Height; y++)
                {
                    var c = new Coord(_index, y);
                    var cell = board.Get(c);

                    _snapshot.Add((c, cell.Base, ToArray(cell.Overlays), ToArray(cell.Markers)));

                    cell.Base = Tags.None;
                    cell.Overlays.Clear();
                    cell.Markers.Clear();
                }
            }

            var payload = new ClearLinePayload
            {
                Axis = _axis,
                Index = _index
            };

            events.Emit(GameEvent.LineCleared, payload);
        }

        /// <summary>
        /// Restores the previous content of the cleared line from the snapshot.
        /// </summary>
        public void Undo(GameState state, IEventSink events)
        {
            if (_snapshot == null)
            {
                return;
            }

            foreach (var item in _snapshot)
            {
                var cell = state.Board.Get(item.pos);
                cell.Base = item.Base;

                cell.Overlays.Clear();

                foreach (var o in item.Overlays)
                {
                    cell.Overlays.Add(o);
                }

                cell.Markers.Clear();

                foreach (var m in item.Markers)
                {
                    cell.Markers.Add(m);
                }
            }
        }

        /// <summary>
        /// Returns a DTO describing which line was cleared.
        /// </summary>
        public object ToPresentationPayload(GameState state)
        {
            return new ClearLinePayload
            {
                Axis = _axis,
                Index = _index
            };
        }

        private static string[] ToArray(HashSet<string> set)
        {
            var arr = new string[set.Count];
            var i = 0;

            foreach (var s in set)
            {
                arr[i++] = s;
            }

            return arr;
        }
    }
}
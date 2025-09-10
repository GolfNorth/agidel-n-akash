using Game.Domain.Core;
using Game.Domain.Events;
using Game.Domain.State;

namespace Game.Domain.Commands
{
    /// <summary>
    /// Places a base tile with the given prototype identifier at a target coordinate.
    /// Emits <see cref="GameEvent.TilePlaced"/> with <see cref="PlaceTilePayload"/>.
    /// The command stores previous base tag to support undo.
    /// </summary>
    public sealed class PlaceTileCmd : ICommand
    {
        private readonly string _protoId;
        private readonly Coord _pos;
        private readonly int _ownerId;

        private string _prevBase;

        /// <summary>
        /// Creates a placement command for a base tile.
        /// </summary>
        public PlaceTileCmd(string protoId, Coord pos, int ownerId)
        {
            _protoId = protoId;
            _pos = pos;
            _ownerId = ownerId;
            _prevBase = null;
        }

        /// <summary>
        /// Applies the placement to the board and emits a TilePlaced event.
        /// </summary>
        public void Do(GameState state, IEventSink events)
        {
            if (!state.Board.InBounds(_pos))
            {
                throw new DomainException($"PlaceTile out of bounds: {_pos}");
            }

            var cell = state.Board.Get(_pos);
            _prevBase = cell.Base;

            state.Board.SetBase(_pos, _protoId);

            var payload = new PlaceTilePayload
            {
                ProtoId = _protoId,
                OwnerId = _ownerId,
                Pos = _pos
            };

            events.Emit(GameEvent.TilePlaced, payload);
        }

        /// <summary>
        /// Restores the previous base tag and emits a TileRemoved event.
        /// </summary>
        public void Undo(GameState state, IEventSink events)
        {
            var restore = _prevBase ?? Tags.None;
            state.Board.SetBase(_pos, restore);

            var payload = new PlaceTilePayload
            {
                ProtoId = _protoId,
                OwnerId = _ownerId,
                Pos = _pos
            };

            events.Emit(GameEvent.TileRemoved, payload);
        }

        /// <summary>
        /// Returns a lightweight DTO for presentation layers (e.g., to animate placement).
        /// </summary>
        public object ToPresentationPayload(GameState state)
        {
            return new PlaceTilePayload
            {
                ProtoId = _protoId,
                OwnerId = _ownerId,
                Pos = _pos
            };
        }
    }
}
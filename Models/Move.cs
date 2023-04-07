using System;

namespace TicTacToeAPI.Models
{
    public class Move
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public DateTime Timestamp { get; set; }

        public Move() { }

        public Move(Guid gameId, Guid playerId, int row, int column)
        {
            Id = Guid.NewGuid();
            GameId = gameId;
            PlayerId = playerId;
            Row = row;
            Column = column;
            Timestamp = DateTime.UtcNow;
        }
    }
}

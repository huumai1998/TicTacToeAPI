using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeAPI.Models
{
    public class Move
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public Move() { }

        public Move(Guid playerId, Guid gameId, int row, int column)
        {
            Id = Guid.NewGuid();
            PlayerId = playerId;
            GameId = gameId;
            Row = row;
            Column = column;
        }
    }
}

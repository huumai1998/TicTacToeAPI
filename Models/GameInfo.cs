using System;

namespace TicTacToeAPI.Models
{
    public class GameInfo
    {
        public Guid Id { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int NumberOfMoves { get; set; }
        public bool GameOver { get; set; }
    }
}

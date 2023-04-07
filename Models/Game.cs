using System;
using System.Collections.Generic;

namespace TicTacToeAPI.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid Player1Id { get; set; }
        public Player Player1 { get; set; }
        public Guid Player2Id { get; set; }
        public Player Player2 { get; set; }
        public List<Move> Moves { get; set; }
        public bool IsGameOver { get; private set; }

        public Game() { }

        public Game(Guid player1Id, Guid player2Id)
        {
            Id = Guid.NewGuid();
            Player1Id = player1Id;
            Player2Id = player2Id;
            Moves = new List<Move>();
            IsGameOver = false;
        }

        public void RegisterMove(Move move)
        {
            if (IsGameOver)
            {
                throw new InvalidOperationException("Cannot register a move on a finished game.");
            }

            Moves.Add(move);

            if (IsWinningMove(move))
            {
                IsGameOver = true;
            }
        }

        private bool IsWinningMove(Move move)
        {
            var playerMoves = Moves.FindAll(m => m.PlayerId == move.PlayerId);
            int row = move.Row;
            int column = move.Column;

            // Check row
            if (playerMoves.Count(m => m.Row == row) == 3)
            {
                return true;
            }

            // Check column
            if (playerMoves.Count(m => m.Column == column) == 3)
            {
                return true;
            }

            // Check diagonal
            if (row == column && playerMoves.Count(m => m.Row == m.Column) == 3)
            {
                return true;
            }

            // Check anti-diagonal
            if (row + column == 2 && playerMoves.Count(m => m.Row + m.Column == 2) == 3)
            {
                return true;
            }

            return false;
        }
    }
}

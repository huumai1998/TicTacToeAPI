using System;

namespace TicTacToeAPI.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PlayerSymbol Symbol { get; set; }
        public ICollection<Move> Moves { get; set; } = new List<Move>();

        public Player() { }

        public Player(string name, PlayerSymbol symbol)
        {
            Id = Guid.NewGuid();
            Name = name;
            Symbol = symbol;
        }
    }

    public enum PlayerSymbol
    {
        X,
        O
    }
}

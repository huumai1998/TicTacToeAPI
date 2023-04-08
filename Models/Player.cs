using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Move> Moves { get; set; }

        public Player() { }

        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Moves = new List<Move>();
        }
    }
}

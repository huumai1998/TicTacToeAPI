using System;
using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class MoveRequest
    {
        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int Column { get; set; }
    }
}

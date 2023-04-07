using System;
using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class MoveRequest
    {
        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        [Range(0, 2)]
        public int Row { get; set; }

        [Required]
        [Range(0, 2)]
        public int Column { get; set; }
    }
}

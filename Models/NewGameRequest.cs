using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class NewGameRequest
    {
        [Required]
        public string? Player1Name { get; set; }

        [Required]
        public string? Player2Name { get; set; }
    }
}

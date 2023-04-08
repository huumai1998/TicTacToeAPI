using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class NewGameRequest
    {
        [Required]
        public string? Player1Id { get; set; }

        [Required]
        public string? Player2Id { get; set; }
    }
}

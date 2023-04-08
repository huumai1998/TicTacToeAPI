using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Data;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly TicTacToeDbContext _context;

        public PlayersController(TicTacToeDbContext context)
        {
            _context = context;
        }

        // GET: api/players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            return _context.Players.ToList();
        }

        // GET: api/players/{id}
        [HttpGet("{id}")]
        public ActionResult<Player> GetPlayerById(string id)
        {
            var player = _context.Players.Find(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // POST: api/players
        [HttpPost]
        public ActionResult<Player> CreatePlayer([FromBody] Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Models;
using TicTacToeAPI.Data;

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

        // GET: api/Players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            return _context.Players.ToList();
        }

        // GET: api/Players/{id}
        [HttpGet("{id}")]
        public ActionResult<Player> GetPlayer(Guid id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return NotFound("Player not found.");
            }

            return player;
        }
    }
}

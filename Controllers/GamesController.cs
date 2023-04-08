using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Data;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly TicTacToeDbContext _context;

        public GamesController(TicTacToeDbContext context)
        {
            _context = context;
        }

        // POST: api/games
        [HttpPost]
        public ActionResult<Game> StartGame([FromBody] NewGameRequest request)
        {
            var player1 = _context.Players.Find(request.Player1Id);
            var player2 = _context.Players.Find(request.Player2Id);

            if (player1 == null || player2 == null)
            {
                return NotFound("One or both player IDs not found.");
            }

            var game = new Game(player1.Id, player2.Id);
            _context.Games.Add(game);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // PUT: api/games/{id}/moves
        [HttpPut("{id}/moves")]
        public IActionResult RegisterMove(Guid id, [FromBody] MoveRequest moveRequest)
        {
            var game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound("Game not found.");
            }

            var move = new Move(moveRequest.PlayerId, id, moveRequest.Row, moveRequest.Column);
            game.RegisterMove(move);

            _context.Moves.Add(move);
            _context.SaveChanges();

            if (game.IsGameOver)
            {
                return Ok(new { message = "Move registered. Game over." });
            }
            else
            {
                return Ok(new { message = "Move registered." });
            }
        }

        // GET: api/games
        [HttpGet]
        public ActionResult<IEnumerable<GameInfo>> GetGames()
        {
            return _context.Games.Select(g => new GameInfo
            {
                Id = g.Id,
                Player1Name = g.Player1.Name,
                Player2Name = g.Player2.Name,
                NumberOfMoves = g.Moves.Count
            }).ToList();
        }

        // GET: api/games/{id}
        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(Guid id)
        {
            var game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }
    }
}

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
    public class GamesController : ControllerBase
    {
        private readonly TicTacToeDbContext _context;

        public GamesController(TicTacToeDbContext context)
        {
            _context = context;
        }

        // POST: api/Games
        [HttpPost]
        public ActionResult<Game> StartGame([FromBody] NewGameRequest request)
        {
            var player1 = new Player(request.Player1Name, PlayerSymbol.X);
            var player2 = new Player(request.Player2Name, PlayerSymbol.O);

            var game = new Game(player1.Id, player2.Id);

            _context.Players.AddRange(player1, player2);
            _context.Games.Add(game);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // POST: api/Games/{id}/moves
        [HttpPost("{id}/moves")]
        public ActionResult RegisterMove(Guid id, [FromBody] MoveRequest moveRequest)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return NotFound("Game not found.");
            }

            var player = _context.Players.FirstOrDefault(p => p.Id == moveRequest.PlayerId);

            if (player == null)
            {
                return NotFound("Player not found.");
            }

            var move = new Move(id, moveRequest.PlayerId, moveRequest.Row, moveRequest.Column);
            game.RegisterMove(move);

            _context.Moves.Add(move);
            _context.SaveChanges();

            if (game.IsGameOver)
            {
                return Ok("Game over. Player " + player.Name + " wins!");
            }

            return Ok("Move registered.");
        }

        // GET: api/Games
        [HttpGet]
        public ActionResult<IEnumerable<GameInfo>> GetRunningGames()
        {
            var games = _context.Games
                .Select(g => new GameInfo
                {
                    Id = g.Id,
                    Player1Name = g.Player1.Name,
                    Player2Name = g.Player2.Name,
                    MovesCount = g.Moves.Count,
                    GameOver = g.IsGameOver
                })
                .Where(gi => !gi.GameOver)
                .ToList();

            return games;
        }

        // GET: api/Games/{id}
        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(Guid id)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return NotFound("Game not found.");
            }

            return game;
        }
    }
}

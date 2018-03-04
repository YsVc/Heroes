using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Data;
using Heroes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly HeroesContext _context;

        public PlayersController(HeroesContext context)
        {
            _context = context;
        }


        // GET api/players
        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            return await _context.Players.ToListAsync();
        }

        // GET api/players/detailed
        [HttpGet("detailed")]
        public IEnumerable<PlayerDetailedViewModel> GetDetailed()
        {
            var players = _context.Players.Include(p => p.MatchHistory).ThenInclude(m => m.Match);

            return players.Select(p => new PlayerDetailedViewModel()
            {
                ID = p.ID,
                Name = p.Name,
                Winrate = p.MatchHistory.Count(m => !(m.Match.IsBlueTeamWon ^ m.IsInBlueTeam)) / (float)p.MatchHistory.Count,
                KDARatio = p.MatchHistory.Sum(m => (m.Kills + m.Assists) / (float)m.Deaths),
                FavHero = _context.Heroes.SingleOrDefault(h => h.ID == p.MatchHistory.GroupBy(m => m.HeroID).Max(a => a.Key))
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Data;
using Heroes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private readonly HeroesContext _context;

        public HeroesController(HeroesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Hero>> Get()
        {
            return await _context.Heroes.ToListAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _context.Heroes.SingleOrDefaultAsync(h => h.ID == id);

            if (hero != null)
            {
                return Json(hero);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("detailed")]
        public async Task<IEnumerable<HeroDetailedViewModel>> GetDetailed()
        {
            var hero = await _context.Heroes.Include(h => h.MatchHistory).ThenInclude(m => m.Match).ToListAsync();

            return hero.Select(h => new HeroDetailedViewModel()
            {
                ID = h.ID,
                Name = h.Name,
                Winrate = h.MatchHistory.Count(m => !(m.IsInBlueTeam ^ m.Match.IsBlueTeamWon)) / (float)h.MatchHistory.Count,
                Popularity = h.MatchHistory.Count / (float)_context.Matches.Count(),
                KDARatio = h.MatchHistory.Sum(m => (m.Kills + m.Assists) / (float)m.Deaths)
            });
        }
    }
}

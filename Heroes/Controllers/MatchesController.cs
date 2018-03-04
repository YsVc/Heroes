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
    public class MatchesController : Controller
    {
        private readonly HeroesContext _context;

        public MatchesController(HeroesContext context)
        {
            _context = context;
        }

        // GET api/matches
        [HttpGet]
        public async Task<IEnumerable<Match>> Get()
        {
            return await _context.Matches.Include(m => m.Map)
                .Include(m => m.Participants).ThenInclude(p => p.Hero)
                .Include(m => m.Participants).ThenInclude(p => p.Player).ToListAsync();
        }



        /* POST api/matches
         * {
         *     mapId: [number], 
         *     duration: [number],
         *     isBlueTeamWon: [boolean],
         *     participants : [{
         *          playerId: [number],
         *          heroId: [number],
         *          isInBlueTeam: [boolean],
         *          kills: [number],
         *          deaths: [number],
         *          assists: [number],   
         *     }, ...]
         * }
        */
        [HttpPost]
        public async Task<IActionResult> AddMatch([FromBody] Match model)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.SingleOrDefaultAsync(m => m.ID == id);
            if (match == null)
                return BadRequest();

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}

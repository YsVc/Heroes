using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Models
{
    public class Match
    {
        public int ID { get; set; }

        public int Duration { get; set; }

        public List<MatchEntry> Participants { get; set; }

        public int MapID { get; set; }
        public Map Map { get; set; }

        public bool IsBlueTeamWon { get; set; }
    }
}

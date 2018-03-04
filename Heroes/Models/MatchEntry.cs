using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Heroes.Models
{
    public class MatchEntry
    {
        [JsonIgnore]
        public int ID { get; set; }

        public int MatchID { get; set; }
        [JsonIgnore]
        public Match Match { get; set; }

        public int HeroID { get; set; }
        public Hero Hero { get; set; }

        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public bool IsInBlueTeam { get; set; }
    }
}

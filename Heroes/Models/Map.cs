using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Heroes.Models
{
    public class Map
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        [JsonIgnore]
        public List<Match> PlayedMatches { get; set; }
    }
}

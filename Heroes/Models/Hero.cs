using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Heroes.Models
{
    public class Hero
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<MatchEntry> MatchHistory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Models
{
    public class HeroDetailedViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public float Winrate { get; set; }

        public float Popularity { get; set; }

        public float KDARatio { get; set; }
    }
}

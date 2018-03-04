using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Models;

namespace Heroes.Data
{
    public static class HeroesContextSeeding
    {
        public static void Seed(HeroesContext context)
        {
            context.Database.EnsureCreated();
            if (context.Heroes.Any())
            {
                return;
            }

            var heroes = new Hero[]
            {
                new Hero() {Name = "Auriel"},
                new Hero() {Name = "Lunara"},
                new Hero() {Name = "Tyrande"},
                new Hero() {Name = "Alexstrasza"},
                new Hero() {Name = "Genji"},
                new Hero() {Name = "Blaze"},
                new Hero() {Name = "Stukov"},
                new Hero() {Name = "Ragnaros"},
                new Hero() {Name = "Alarak"},
                new Hero() {Name = "Xul"}
            };
            context.Heroes.AddRange(heroes);
            context.SaveChanges();

            var maps = new Map[]
            {
                new Map() {Name = "volskaya-foundry", FullName = "Volskaya Foundry"},
                new Map() {Name = "towers-of-doom", FullName = "Towers of Doom"},
                new Map() {Name = "dragon-shire", FullName = "Dragon Shire"}
            };
            context.Maps.AddRange(maps);
            context.SaveChanges();

            var players = new Player[]
            {
                new Player() { Name = "Ethan"},
                new Player() { Name = "Bobby"},
                new Player() { Name = "George"},
                new Player() { Name = "Samuel"},
                new Player() { Name = "Nicholas"},
                new Player() { Name = "Luis"},
                new Player() { Name = "Rogelio"},
                new Player() { Name = "Anderson"},
                new Player() { Name = "Andre"},
                new Player() { Name = "Damian"}
            };
            context.Players.AddRange(players);
            context.SaveChanges();

            var matches = new Match[]
            {
                new Match(){ Map = maps[0], Duration = 600, IsBlueTeamWon = true, Participants = new List<MatchEntry>()
                {
                    new MatchEntry() { Player = players[0], Hero = heroes[0], Kills = 5, Assists = 3, Deaths = 4, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[1], Hero = heroes[1], Kills = 6, Assists = 4, Deaths = 3, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[2], Hero = heroes[2], Kills = 3, Assists = 5, Deaths = 1, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[3], Hero = heroes[3], Kills = 6, Assists = 2, Deaths = 3, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[4], Hero = heroes[4], Kills = 7, Assists = 1, Deaths = 2, IsInBlueTeam = true },

                    new MatchEntry() { Player = players[5], Hero = heroes[5], Kills = 1, Assists = 1, Deaths = 5, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[6], Hero = heroes[6], Kills = 3, Assists = 2, Deaths = 4, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[7], Hero = heroes[7], Kills = 2, Assists = 3, Deaths = 6, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[8], Hero = heroes[8], Kills = 3, Assists = 1, Deaths = 1, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[9], Hero = heroes[9], Kills = 2, Assists = 1, Deaths = 3, IsInBlueTeam = false }
                }},

                new Match(){ Map = maps[1], Duration = 876, IsBlueTeamWon = true, Participants = new List<MatchEntry>()
                {
                    new MatchEntry() { Player = players[8], Hero = heroes[9], Kills = 5, Assists = 3, Deaths = 4, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[4], Hero = heroes[8], Kills = 6, Assists = 4, Deaths = 3, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[9], Hero = heroes[7], Kills = 3, Assists = 5, Deaths = 1, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[3], Hero = heroes[6], Kills = 6, Assists = 2, Deaths = 3, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[1], Hero = heroes[5], Kills = 7, Assists = 1, Deaths = 2, IsInBlueTeam = true },

                    new MatchEntry() { Player = players[0], Hero = heroes[4], Kills = 1, Assists = 1, Deaths = 5, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[2], Hero = heroes[3], Kills = 3, Assists = 2, Deaths = 4, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[7], Hero = heroes[2], Kills = 2, Assists = 3, Deaths = 6, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[6], Hero = heroes[1], Kills = 3, Assists = 1, Deaths = 1, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[5], Hero = heroes[0], Kills = 2, Assists = 1, Deaths = 3, IsInBlueTeam = false },
                }},

                new Match(){ Map = maps[2], Duration = 576, IsBlueTeamWon = false, Participants = new List<MatchEntry>()
                {
                    new MatchEntry() { Player = players[6], Hero = heroes[0], Kills = 5, Assists = 3, Deaths = 4, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[4], Hero = heroes[3], Kills = 6, Assists = 4, Deaths = 3, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[5], Hero = heroes[4], Kills = 3, Assists = 5, Deaths = 1, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[3], Hero = heroes[6], Kills = 6, Assists = 2, Deaths = 3, IsInBlueTeam = true },
                    new MatchEntry() { Player = players[1], Hero = heroes[7], Kills = 7, Assists = 1, Deaths = 2, IsInBlueTeam = true },

                    new MatchEntry() { Player = players[0], Hero = heroes[9], Kills = 1, Assists = 1, Deaths = 5, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[2], Hero = heroes[8], Kills = 3, Assists = 2, Deaths = 4, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[7], Hero = heroes[5], Kills = 2, Assists = 3, Deaths = 6, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[8], Hero = heroes[2], Kills = 3, Assists = 1, Deaths = 1, IsInBlueTeam = false },
                    new MatchEntry() { Player = players[9], Hero = heroes[1], Kills = 2, Assists = 1, Deaths = 3, IsInBlueTeam = false },
                }}
            };
            context.Matches.AddRange(matches);
            context.SaveChanges();           
        }
    }
}

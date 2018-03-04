using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Data
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().ToTable("Heroes");
            modelBuilder.Entity<Match>().ToTable("Matches");
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<MatchEntry>().ToTable("MatchEntries");
            modelBuilder.Entity<Map>().ToTable("Maps");

            modelBuilder.Entity<Hero>().Property(h => h.Name).HasMaxLength(25).IsRequired();


            modelBuilder.Entity<Player>().Property(p => p.Name).HasMaxLength(25).IsRequired();

            modelBuilder.Entity<MatchEntry>().Property(m => m.Kills).HasDefaultValue(0);
            modelBuilder.Entity<MatchEntry>().Property(m => m.Deaths).HasDefaultValue(0);
            modelBuilder.Entity<MatchEntry>().Property(m => m.Assists).HasDefaultValue(0);
            modelBuilder.Entity<MatchEntry>().Property(m => m.IsInBlueTeam).HasDefaultValue(false);
            
            modelBuilder.Entity<Player>().HasMany(p => p.MatchHistory).WithOne(m => m.Player)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Hero>().HasMany(h => h.MatchHistory).WithOne(m => m.Hero)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Match>().HasOne(m => m.Map).WithMany(m => m.PlayedMatches)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Match>().HasMany(m => m.Participants).WithOne(p => p.Match)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

        }
    }
}

﻿// <auto-generated />
using Heroes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Heroes.Migrations
{
    [DbContext(typeof(HeroesContext))]
    partial class HeroesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Heroes.Models.Hero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Heroes.Models.Map", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("Heroes.Models.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duration");

                    b.Property<bool>("IsBlueTeamWon");

                    b.Property<int?>("MapID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("MapID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Heroes.Models.MatchEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Assists")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Deaths")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("HeroID")
                        .IsRequired();

                    b.Property<bool>("IsInBlueTeam")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("Kills")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("MatchID")
                        .IsRequired();

                    b.Property<int?>("PlayerID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("HeroID");

                    b.HasIndex("MatchID");

                    b.HasIndex("PlayerID");

                    b.ToTable("MatchEntries");
                });

            modelBuilder.Entity("Heroes.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Heroes.Models.Match", b =>
                {
                    b.HasOne("Heroes.Models.Map", "Map")
                        .WithMany("PlayedMatches")
                        .HasForeignKey("MapID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Heroes.Models.MatchEntry", b =>
                {
                    b.HasOne("Heroes.Models.Hero", "Hero")
                        .WithMany("MatchHistory")
                        .HasForeignKey("HeroID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Heroes.Models.Match", "Match")
                        .WithMany("Participants")
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Heroes.Models.Player", "Player")
                        .WithMany("MatchHistory")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

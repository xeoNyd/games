﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cybersport.Data;

namespace cybersport.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191129233126_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("cybersport.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Game_result");

                    b.Property<int?>("GenreID");

                    b.Property<int>("NameOfGameID");

                    b.Property<int>("Team1ID");

                    b.Property<int>("Team2ID");

                    b.HasKey("GameID");

                    b.HasIndex("GenreID");

                    b.HasIndex("NameOfGameID");

                    b.HasIndex("Team1ID");

                    b.HasIndex("Team2ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("cybersport.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre_description")
                        .IsRequired();

                    b.Property<string>("Genre_name")
                        .IsRequired();

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("cybersport.Models.League", b =>
                {
                    b.Property<int>("LeagueID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Leag_Type")
                        .IsRequired();

                    b.Property<string>("Leag_name")
                        .IsRequired();

                    b.Property<int>("Leag_team_num");

                    b.Property<int>("NameOfGameID");

                    b.Property<int>("prize_pool");

                    b.HasKey("LeagueID");

                    b.HasIndex("NameOfGameID");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("cybersport.Models.Manager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manager_email")
                        .IsRequired();

                    b.Property<string>("Manager_name")
                        .IsRequired();

                    b.Property<string>("Manager_surname")
                        .IsRequired();

                    b.Property<int>("TeamID");

                    b.HasKey("ManagerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("cybersport.Models.NameOfGame", b =>
                {
                    b.Property<int>("NameOfGameID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Game_description")
                        .IsRequired();

                    b.Property<int>("GenreID");

                    b.Property<string>("Name_of_Game")
                        .IsRequired();

                    b.HasKey("NameOfGameID");

                    b.HasIndex("GenreID");

                    b.ToTable("NameOfGames");
                });

            modelBuilder.Entity("cybersport.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Player_email")
                        .IsRequired();

                    b.Property<string>("Player_name")
                        .IsRequired();

                    b.Property<string>("Player_nickname")
                        .IsRequired();

                    b.Property<int>("Player_rate");

                    b.Property<string>("Player_surname")
                        .IsRequired();

                    b.Property<int>("TeamID");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("cybersport.Models.PlayingGame", b =>
                {
                    b.Property<int>("PlayingGameID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NameOfGameID");

                    b.Property<int>("TeamID");

                    b.HasKey("PlayingGameID");

                    b.HasIndex("NameOfGameID");

                    b.HasIndex("TeamID");

                    b.ToTable("PlayingGames");
                });

            modelBuilder.Entity("cybersport.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeagueID");

                    b.Property<string>("Team_name")
                        .IsRequired();

                    b.HasKey("TeamID");

                    b.HasIndex("LeagueID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("cybersport.Models.Game", b =>
                {
                    b.HasOne("cybersport.Models.Genre")
                        .WithMany("games")
                        .HasForeignKey("GenreID");

                    b.HasOne("cybersport.Models.NameOfGame", "nameOfGame")
                        .WithMany()
                        .HasForeignKey("NameOfGameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cybersport.Models.Team", "team1")
                        .WithMany()
                        .HasForeignKey("Team1ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cybersport.Models.Team", "team2")
                        .WithMany()
                        .HasForeignKey("Team2ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cybersport.Models.League", b =>
                {
                    b.HasOne("cybersport.Models.NameOfGame", "nameOfGame")
                        .WithMany()
                        .HasForeignKey("NameOfGameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cybersport.Models.Manager", b =>
                {
                    b.HasOne("cybersport.Models.Team", "team")
                        .WithMany("manager")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cybersport.Models.NameOfGame", b =>
                {
                    b.HasOne("cybersport.Models.Genre", "genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cybersport.Models.Player", b =>
                {
                    b.HasOne("cybersport.Models.Team", "team")
                        .WithMany("players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cybersport.Models.PlayingGame", b =>
                {
                    b.HasOne("cybersport.Models.NameOfGame", "nameOfGame")
                        .WithMany("teams")
                        .HasForeignKey("NameOfGameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cybersport.Models.Team", "team")
                        .WithMany("games")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cybersport.Models.Team", b =>
                {
                    b.HasOne("cybersport.Models.League")
                        .WithMany("teams")
                        .HasForeignKey("LeagueID");
                });
#pragma warning restore 612, 618
        }
    }
}

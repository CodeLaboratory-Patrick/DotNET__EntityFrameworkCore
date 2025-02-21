using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "FootballLeague_EfCore.db");
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Using SQL Server
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeage_EfCore; Encrypt=False");

            //Using SQLite
            optionsBuilder.UseSqlite($"Data Source={DbPath}")
                //Query Tracking Behavior
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)

                .LogTo(Console.WriteLine, LogLevel.Information)

                //EnableSensitiveDataLogging + EnableDetailedErrors => Do not use this in production
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Liverpool",
                    CreatedDate = new DateTime(2023, 1, 1, 01, 01, 01, DateTimeKind.Utc)
                },
                 new Team
                 {
                     Id = 2,
                     Name = "Arsenal",
                     CreatedDate = new DateTime(2023, 1, 1, 02, 02, 02, DateTimeKind.Utc)
                 },
                  new Team
                  {
                      Id = 3,
                      Name = "Tottenham Hotspur",
                      CreatedDate = new DateTime(2023, 1, 1, 03, 03, 03, DateTimeKind.Utc)
                  },
                   new Team
                   {
                       Id = 4,
                       Name = "Manchester City",
                       CreatedDate = new DateTime(2023, 1, 1, 04, 04, 04, DateTimeKind.Utc)
                   });
        }

    }
}

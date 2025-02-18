using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Using SQL Server
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeage_EfCore; Encrypt=False");

            //Using SQLite
            optionsBuilder.UseSqlite($"Data Source=FootballLeage_EfCore.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "Liverpool",
                    CreatedDate = new DateTime(2023, 1, 1, 01, 01, 01, DateTimeKind.Utc)
                },
                 new Team
                 {
                     TeamId = 2,
                     Name = "Arsenal",
                     CreatedDate = new DateTime(2023, 1, 1, 02, 02, 02, DateTimeKind.Utc)
                 },
                  new Team
                  {
                      TeamId = 3,
                      Name = "Tottenham Hotspur",
                      CreatedDate = new DateTime(2023, 1, 1, 03, 03, 03, DateTimeKind.Utc)
                  },
                   new Team
                   {
                       TeamId = 4,
                       Name = "Manchester City",
                       CreatedDate = new DateTime(2023, 1, 1, 04, 04, 04, DateTimeKind.Utc)
                   });
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
    }
}

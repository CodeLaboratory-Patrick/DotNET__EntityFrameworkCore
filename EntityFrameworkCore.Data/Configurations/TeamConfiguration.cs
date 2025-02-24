using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasIndex(m => m.Name).IsUnique();

            builder.HasMany(e => e.HomeMatches)
                .WithOne(e => e.HomeTeam)
                .HasForeignKey(e => e.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.AwayMatches)
                .WithOne(e => e.AwayTeam)
                .HasForeignKey(e => e.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
               new Team
               {
                   Id = 1,
                   Name = "Liverpool",
                   CreatedDate = new DateTime(2023, 1, 1, 01, 01, 01, DateTimeKind.Utc),
                   LeagueId = 1,
                   CoachId = 1
               },
               new Team
               {
                   Id = 2,
                   Name = "Arsenal",
                   CreatedDate = new DateTime(2023, 1, 1, 02, 02, 02, DateTimeKind.Utc),
                   LeagueId = 1,
                   CoachId = 2
               },
               new Team
               {
                   Id = 3,
                   Name = "Tottenham Hotspur",
                   CreatedDate = new DateTime(2023, 1, 1, 03, 03, 03, DateTimeKind.Utc),
                   LeagueId = 1,
                   CoachId = 3
               },
               new Team
               {
                   Id = 4,
                   Name = "Manchester City",
                   CreatedDate = new DateTime(2023, 1, 1, 04, 04, 04, DateTimeKind.Utc),
                   LeagueId = 1,
                   CoachId = 4
               }
            );
        }
    }
}

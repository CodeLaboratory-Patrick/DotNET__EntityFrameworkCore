using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);


            builder.HasData(
               new League
               {
                   Id = 1,
                   Name = "Premier League (England)",
               },
               new League
               {
                   Id = 2,
                   Name = "Bundesliga (Germany)",
               },
               new League
               {
                   Id = 3,
                   Name = "LaLiga (Spain)",
               },
               new League
               {
                   Id = 4,
                   Name = "Ligue 1 (France)",
               },
                new League
               {
                   Id = 5,
                   Name = "Serie A(Italy)",
               }
            );
        }
    }
}

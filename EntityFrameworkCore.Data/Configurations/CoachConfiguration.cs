using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(
               new Coach
               {
                   Id = 1,
                   Name = "Arsène Wenger",
               },
               new Coach
               {
                   Id = 2,
                   Name = "Didier Deschamps",
               },
               new Coach
               {
                   Id = 3,
                   Name = "Albert Batteux",
               },
               new Coach
               {
                   Id = 4,
                   Name = "Laurent Blanc",
               },
                new Coach
                {
                    Id = 5,
                    Name = "Carlo Ancelotti",
                }
            );
        }
    }
}

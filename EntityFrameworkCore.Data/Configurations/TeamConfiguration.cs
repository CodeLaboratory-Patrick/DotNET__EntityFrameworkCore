using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
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
               }   
            );
        }
    }
}

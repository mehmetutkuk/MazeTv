using MazeTV.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTV.Persistence.Configuration
{
    public class ShowPersonConfiguration : IEntityTypeConfiguration<ShowPerson>
    {
        void IEntityTypeConfiguration<ShowPerson>.Configure(EntityTypeBuilder<ShowPerson> builder)
        {
            builder.ToTable("ShowPeople").HasKey(x => new { x.PersonId, x.ShowId });
         //   builder.HasOne(x => x.Show).WithMany(x => x.Cast).HasForeignKey(s=> s.ShowId).OnDelete(DeleteBehavior.Cascade);
          //  builder.HasOne(x => x.Person).WithMany(x => x.Show).HasForeignKey(s=> s.PersonId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

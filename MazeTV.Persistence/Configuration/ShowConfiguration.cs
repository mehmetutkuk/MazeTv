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
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        void IEntityTypeConfiguration<Show>.Configure(EntityTypeBuilder<Show> builder)
        {
            builder.ToTable("Shows");
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(240);
            builder.HasMany(x => x.Cast).WithOne(x => x.Show).HasForeignKey(s => s.ShowId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

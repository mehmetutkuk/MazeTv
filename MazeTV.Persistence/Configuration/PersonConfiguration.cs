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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);
            builder.Property(s=> s.Name).IsRequired().HasMaxLength(140);
            builder.HasMany(x => x.Show).WithOne(x => x.Person).HasForeignKey(s => s.PersonId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}

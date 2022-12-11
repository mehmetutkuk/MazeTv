using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MazeTV.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Design;
using MazeTV.Persistence.Configuration;

namespace MazeTV.Persistence
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}
        public DbSet<Person> Persons { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowPerson> ShowPeople { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ShowConfiguration());
            modelBuilder.ApplyConfiguration(new ShowPersonConfiguration());
        }
       
    }
}


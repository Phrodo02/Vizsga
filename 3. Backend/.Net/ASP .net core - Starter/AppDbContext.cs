using Microsoft.EntityFrameworkCore;
using Vizsga_ASP_NET.Models;

namespace Vizsga_ASP_NET
{
    public class AppDbContext: DbContext
    {
        public DbSet<Example> Examples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost; database=dbName; uid=root; pwd=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example>().HasIndex(k => k.Name).IsUnique();

            modelBuilder.Entity<Example>().HasData(
                new Example() { Id = 1, Name = "example" },
                new Example() { Id = 2, Name = "example" }
            );
        }

        //Add-Migration

        //Script-Migration ==>

        //Create Database example
            //character set utf8
            //collate utf8_hungarian_ci;

        //use example;

        //Update-Database

    }
}

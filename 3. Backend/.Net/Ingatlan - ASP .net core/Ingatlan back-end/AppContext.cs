using Ingatlan_back_end.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ingatlan_back_end
{
    public class AppContext: DbContext
    {
        public DbSet<IngatlanModel> Ingatlanok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost; database=ingatlan; uid=root; pwd=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KategoriaModel>().HasIndex(k => k.Nev).IsUnique();

            modelBuilder.Entity<KategoriaModel>().HasData(
                new KategoriaModel() { Id = 1, Nev = "Ház"},
                new KategoriaModel() { Id = 2, Nev = "Lakás"},
                new KategoriaModel() { Id = 3, Nev = "Építési telek"},
                new KategoriaModel() { Id = 4, Nev = "Garázs"},
                new KategoriaModel() { Id = 5, Nev = "Mezőgazdasági terület"},
                new KategoriaModel() { Id = 6, Nev = "Ipari ingatlan"}
            );
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RealEstateGUI.Models
{
    public partial class ingatlanContext : DbContext
    {
        public ingatlanContext()
        {
        }

        public ingatlanContext(DbContextOptions<ingatlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Realestates> Realestates { get; set; }
        public virtual DbSet<Sellers> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=ingatlan;uid=root", x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_hungarian_ci");
            });

            modelBuilder.Entity<Realestates>(entity =>
            {
                entity.ToTable("realestates");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_realestates_categoryId");

                entity.HasIndex(e => e.SellerId)
                    .HasName("FK_realestates_sellerId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("createAt")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_hungarian_ci");

                entity.Property(e => e.Floors)
                    .HasColumnName("floors")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Freeofcharge).HasColumnName("freeofcharge");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("imageUrl")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_hungarian_ci");

                entity.Property(e => e.Latlong)
                    .HasColumnName("latlong")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_hungarian_ci");

                entity.Property(e => e.Rooms)
                    .HasColumnName("rooms")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SellerId)
                    .HasColumnName("sellerId")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Realestates)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_realestates_categoryId");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Realestates)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_realestates_sellerId");
            });

            modelBuilder.Entity<Sellers>(entity =>
            {
                entity.ToTable("sellers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_hungarian_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_hungarian_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

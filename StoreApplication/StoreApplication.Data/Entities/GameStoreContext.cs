using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreApplication.Data.Entities
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<OrderedProducts> OrderedProducts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64D8996736AA");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Inventory1).HasColumnName("Inventory");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Inventory__Locat__278EDA44");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__2882FE7D");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Location__E7FEA49761DD256F");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderedProducts>(entity =>
            {
                entity.HasKey(e => e.Opid)
                    .HasName("PK__OrderedP__AE2CBEFEBDE46CE4");

                entity.Property(e => e.Opid).HasColumnName("OPId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderedPr__Custo__21D600EE");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__OrderedPr__Locat__24B26D99");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderedPr__Order__22CA2527");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderedPr__Produ__23BE4960");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCFF9ACD538");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__1EF99443");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CDF1013252");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

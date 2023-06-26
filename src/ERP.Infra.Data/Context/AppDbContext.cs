using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.Description)
                    .HasMaxLength(100);
            });

            builder.Entity<Supplier>(entity =>
            {
                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.Address)
                    .HasMaxLength(100);

                entity.Property(x => x.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(x => x.Email)
                    .HasMaxLength(100);

                entity.Property(x => x.CreationDate)
                    .HasDefaultValueSql("Getdate()")
                    .ValueGeneratedOnAdd();

            });

            builder.Entity<Product>(entity =>
            {
                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.Description)
                    .HasMaxLength(300);

                entity.Property(x => x.BarCode)
                    .HasMaxLength(50);

                entity.Property(x => x.Price)
                    .HasPrecision(10, 2);

                entity.Property(x => x.StockQuantity);

                entity.Property(x => x.CreationDate)
                    .HasDefaultValueSql("Getdate()")
                    .ValueGeneratedOnAdd();

                entity.HasOne(x => x.Supplier)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.SupplierId);

                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId);
            });

            builder.Entity<Client>(entity =>
            {
                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.Address)
                    .HasMaxLength(200);

                entity.Property(x => x.District)
                    .HasMaxLength(100);

                entity.Property(x => x.Number);

                entity.Property(x => x.Email)
                    .HasMaxLength(200);

                entity.Property(x => x.Phone)
                    .HasMaxLength(20);

            });

            builder.Entity<Order>(entity =>
            {
                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.ClientId)
                    .IsRequired();

                entity.Property(x => x.CreationDate)
                    .HasDefaultValueSql("Getdate()")
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.PaymentMethod)
                    .IsRequired();

                entity.Property(x => x.OrderStatus)
                    .IsRequired();

                entity.Property(x => x.Total)
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.HasOne(x => x.Client)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.ClientId);
            });
        }
    }
}

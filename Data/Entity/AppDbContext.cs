using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Entity
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration["ConnectionStrings:MySql"], ServerVersion.AutoDetect(_configuration["ConnectionStrings:MySql"]));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id).HasName("PRIMARY");
                entity.ToTable("categories");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(c => c.Id).HasName("PRIMARY");
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnName("price").HasPrecision(10,2);
                entity.Property(e => e.Stock).HasColumnName("stock");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.HasOne(e => e.Category).WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId).HasConstraintName("products_ibfk_1");
            });
        }
    }
}

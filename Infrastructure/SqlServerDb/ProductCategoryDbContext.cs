using Application.Application.Abstractions;
using Application.Entities;
using Application.Entities.Categories;
using Application.Entities.Products;
using Application.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServerDb;
public class ProductCategoryDbContext : IdentityDbContext<ApplicationUser>, IDbContext
{
    public ProductCategoryDbContext(DbContextOptions<ProductCategoryDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
          .HasKey(pk => pk.CategoryId);

        modelBuilder.Entity<Product>()
          .HasKey(pk => pk.ProductId);

        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId,pc.CategoryId });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>().Ignore(c => c.Password);

        modelBuilder.Entity<Category>()
        .HasIndex(e => e.CategoryName)
        .IsUnique();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}

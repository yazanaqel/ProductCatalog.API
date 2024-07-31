using Application.Entities;
using Application.Entities.Categories;
using Application.Entities.Products;
using Application.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServerDb;
public class ProductCategoryDbContext : IdentityDbContext<ApplicationUser> {
    public ProductCategoryDbContext(DbContextOptions<ProductCategoryDbContext> options) : base(options) {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.NoAction); // Allows products to be deleted

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents categories from being deleted if they have products

        modelBuilder.Entity<ApplicationUser>().Ignore(c => c.Password);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}

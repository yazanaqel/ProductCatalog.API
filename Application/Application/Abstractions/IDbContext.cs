using Application.Entities;
using Application.Entities.Categories;
using Application.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Abstractions;
public interface IDbContext {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}

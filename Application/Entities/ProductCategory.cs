using Application.Entities.Categories;
using Application.Entities.Products;

namespace Application.Entities;
public class ProductCategory {
    public required string ProductId { get; set; }
    public Product Product { get; set; }

    public required string CategoryId { get; set; }
    public Category Category { get; set; }
}


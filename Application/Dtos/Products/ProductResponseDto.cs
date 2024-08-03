using Application.Entities.Products;

namespace Application.Dtos.Products;
public class ProductResponseDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}
public class ProductsResponseDto(Product product)
{
    public int ProductId { get; set; } = product.ProductId;
    public string ProductName { get; set; } = product.ProductName;
    public decimal Price { get; set; } = product.Price;
}
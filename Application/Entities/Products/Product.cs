using Application.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Entities.Products;
public class Product {
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;


    [Precision(18, 2)]
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public virtual ApplicationUser User { get; set; }
    public string UserId { get; set; } = string.Empty;

    public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
}

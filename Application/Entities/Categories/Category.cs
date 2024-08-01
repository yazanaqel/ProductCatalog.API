using Application.Entities.Users;

namespace Application.Entities.Categories;
public class Category {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public virtual ApplicationUser User { get; set; }
    public string UserId { get; set; } = string.Empty;

    public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
}

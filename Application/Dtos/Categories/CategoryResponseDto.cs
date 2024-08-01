using Application.Entities.Categories;

namespace Application.Dtos.Categories;
public class CategoryResponseDto {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
public class CategoriesResponseDto(Category category) {
    public int CategoryId { get; set; } = category.CategoryId;
    public string CategoryName { get; set; } = category.CategoryName;
}

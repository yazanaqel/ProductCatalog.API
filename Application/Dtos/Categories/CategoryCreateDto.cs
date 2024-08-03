using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Categories;
public class CategoryCreateDto
{
    [Required, MaxLength(15)]
    public string CategoryName { get; set; } = string.Empty;
}

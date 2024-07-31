using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Categories;
public class CategoryCreateDto {
    [Required, MaxLength(15)]
    public required string CategoryName { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Categories;
public class CategoryUpdateDto {
    [Required]
    public required int CategoryId { get; set; }
    [Required, MaxLength(15)]
    public required string CategoryName { get; set; }
}

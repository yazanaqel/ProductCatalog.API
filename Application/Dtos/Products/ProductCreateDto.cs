using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Products;
public class ProductCreateDto {
    [Required]
    public string ProductName { get; set; } = string.Empty;


    [Required, Precision(18, 2)]
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string? Description { get; set; }

    [Required]
    public List<int> CategoriesList { get; set; } = new List<int>();
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Products;
public class ProductUpdateDto {

    [Required]
    public required int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; } = string.Empty;


    [Required, Precision(18, 2)]
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string? Description { get; set; }
}

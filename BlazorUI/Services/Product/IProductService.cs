using Application;
using Application.Dtos.Products;

namespace BlazorUI.Services.Product;

public interface IProductService
{
    Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> GetProductsByCategory(int categoryId);
    Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> GetAllProducts();
    Task<ApplicationResponse<ProductResponseDto>> GetProductById(int productId);
    Task<ApplicationResponse<ProductResponseDto>> CreateProduct(ProductCreateDto product);
    Task<ApplicationResponse<ProductResponseDto>> UpdateProduct(ProductUpdateDto product);
    Task<ApplicationResponse<ProductResponseDto>> DeleteProduct(int productId);
}

using Application;

namespace BlazorUI.Services.Product;

public interface IProductService
{
    Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> GetProductsByCategory(int categoryId);
}

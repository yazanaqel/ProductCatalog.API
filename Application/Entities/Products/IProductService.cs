namespace Application.Entities.Products;
public interface IProductService {
    Task<ApplicationResponse<Product>> CreateProduct(Product product);
    Task<ApplicationResponse<Product>> UpdateProduct(Product product, string userId);
    Task<ApplicationResponse<Product>> DeleteProduct(string productId, string userId);
}

namespace Application.Entities.Products;
public interface IProductService {
    Task<ApplicationResponse<Product>> CreateProduct(Product product, List<int> categoriesList);
    Task<ApplicationResponse<Product>> UpdateProduct(Product product);
    Task<ApplicationResponse<Product>> DeleteProduct(int productId, string userId);
}

using Application;
using Application.Entities.Products;

namespace Infrastructure.SqlServerDb.Repositories;
internal class ProductRepository : IProductService {
    public Task<ApplicationResponse<Product>> CreateProduct(Product product) {
        throw new NotImplementedException();
    }

    public Task<ApplicationResponse<Product>> DeleteProduct(string productId, string userId) {
        throw new NotImplementedException();
    }

    public Task<ApplicationResponse<Product>> UpdateProduct(Product product, string userId) {
        throw new NotImplementedException();
    }
}

using Application;
using Application.Constants;
using Application.Entities;
using Application.Entities.Products;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServerDb.Repositories;
internal class ProductRepository(ProductCategoryDbContext dbContext) : IProductService
{
    private readonly ProductCategoryDbContext _dbContext = dbContext;

    public async Task<ApplicationResponse<Product>> CreateProduct(Product product,List<int> categoriesList)
    {

        var applicationResponse = new ApplicationResponse<Product>();

        try
        {

            product.ProductCategories = categoriesList.Select(categoryId => new ProductCategory
            {

                ProductId = product.ProductId,
                CategoryId = categoryId

            }).ToList();

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();

            applicationResponse.Data = product;
            applicationResponse.Success = true;
        }
        catch(DbUpdateException ex)
        {

            var sqlException = ex.InnerException as SqlException;

            if(sqlException != null)
            {

                applicationResponse.Message = sqlException.Message;
            }
        }

        return applicationResponse;

    }

    public async Task<ApplicationResponse<Product>> DeleteProduct(int productId,string userId)
    {
        var applicationResponse = new ApplicationResponse<Product>();
        try
        {

            var product = await _dbContext.Products.FindAsync(productId);

            if(product is null || product.UserId != userId)
            {
                applicationResponse.Message = CustomConstants.NotFound.Category;
                return applicationResponse;
            }

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            applicationResponse.Message = CustomConstants.Operation.Successful;
            applicationResponse.Success = true;
        }
        catch(DbUpdateException ex)
        {

            var sqlException = ex.InnerException as SqlException;

            if(sqlException != null)
            {

                applicationResponse.Message = sqlException.Message;
            }
        }


        return applicationResponse;
    }


    public async Task<ApplicationResponse<Product>> UpdateProduct(Product product)
    {
        var applicationResponse = new ApplicationResponse<Product>();

        try
        {
            var checkProduct = await _dbContext.Products
                .Where(c => (c.UserId == product.UserId) && (c.ProductId == product.ProductId))
                .AsNoTracking()
                .FirstOrDefaultAsync();


            if(checkProduct is null)
            {
                applicationResponse.Message = CustomConstants.NotFound.Product;
                return applicationResponse;
            }

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            applicationResponse.Data = product;
            applicationResponse.Success = true;
        }
        catch(DbUpdateException ex)
        {

            var sqlException = ex.InnerException as SqlException;

            if(sqlException != null)
            {

                applicationResponse.Message = sqlException.Message;
            }
        }

        return applicationResponse;
    }
}

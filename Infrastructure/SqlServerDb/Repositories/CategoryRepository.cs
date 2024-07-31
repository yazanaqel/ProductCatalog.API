using Application;
using Application.Entities.Categories;

namespace Infrastructure.SqlServerDb.Repositories;
public class CategoryRepository(ProductCategoryDbContext dbContext) : ICategoryService {
    private readonly ProductCategoryDbContext _dbContext = dbContext;

    public async Task<ApplicationResponse<Category>> CreateCategory(Category category) {

        var applicationResponse = new ApplicationResponse<Category>();

        try {

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();


        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }

        applicationResponse.Data = category;
        applicationResponse.Success = true;

        return applicationResponse;

    }

    public Task<ApplicationResponse<Category>> DeleteCategory(string categoryId, string userId) {
        throw new NotImplementedException();
    }

    public Task<ApplicationResponse<Category>> UpdateCategory(Category category, string userId) {
        throw new NotImplementedException();
    }
}

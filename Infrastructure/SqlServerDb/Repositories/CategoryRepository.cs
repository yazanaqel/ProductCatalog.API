using Application;
using Application.Constants;
using Application.Entities.Categories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServerDb.Repositories;
public class CategoryRepository(ProductCategoryDbContext dbContext) : ICategoryService {
    private readonly ProductCategoryDbContext _dbContext = dbContext;

    public async Task<ApplicationResponse<Category>> CreateCategory(Category category) {

        var applicationResponse = new ApplicationResponse<Category>();

        try {

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            applicationResponse.Data = category;
            applicationResponse.Success = true;
        }
        catch (DbUpdateException ex) {

            var sqlException = ex.InnerException as SqlException;

            if (sqlException != null) {

                applicationResponse.Message = sqlException.Message;
            }
        }

        return applicationResponse;

    }

    public async Task<ApplicationResponse<Category>> DeleteCategory(int categoryId, string userId) {
        var applicationResponse = new ApplicationResponse<Category>();
        try {

            var category = await _dbContext.Categories.FindAsync(categoryId);

            if (category is null || category.UserId != userId) {
                applicationResponse.Message = CustomConstants.NotFound.Category;
                return applicationResponse;
            }

            _dbContext.Categories.Remove(category);

            await dbContext.SaveChangesAsync();

            applicationResponse.Message = CustomConstants.Operation.Successful;
            applicationResponse.Success = true;
        }
        catch (DbUpdateException ex) {

            var sqlException = ex.InnerException as SqlException;

            if (sqlException != null) {

                applicationResponse.Message = sqlException.Message;
            }
        }


        return applicationResponse;
    }

    public async Task<ApplicationResponse<Category>> UpdateCategory(Category category) {

        var applicationResponse = new ApplicationResponse<Category>();

        try {
            var checkCategory = await _dbContext.Categories
                .Where(c => (c.UserId == category.UserId) && (c.CategoryId == category.CategoryId))
                .AsNoTracking()
                .FirstOrDefaultAsync();


            if (checkCategory is null) {
                applicationResponse.Message = CustomConstants.NotFound.Category;
                return applicationResponse;
            }

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();

            applicationResponse.Data = category;
            applicationResponse.Success = true;
        }
        catch (DbUpdateException ex) {

            var sqlException = ex.InnerException as SqlException;

            if (sqlException != null) {

                applicationResponse.Message = sqlException.Message;
            }
        }

        return applicationResponse;
    }
}

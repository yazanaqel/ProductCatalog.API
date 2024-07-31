namespace Application.Entities.Categories;
public interface ICategoryService {
    Task<ApplicationResponse<Category>> CreateCategory(Category category);
    Task<ApplicationResponse<Category>> UpdateCategory(Category category, string userId);
    Task<ApplicationResponse<Category>> DeleteCategory(string categoryId, string userId);
}


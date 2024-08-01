namespace Application.Entities.Categories;
public interface ICategoryService {
    Task<ApplicationResponse<Category>> CreateCategory(Category category);
    Task<ApplicationResponse<Category>> UpdateCategory(Category category);
    Task<ApplicationResponse<Category>> DeleteCategory(int categoryId, string userId);
}


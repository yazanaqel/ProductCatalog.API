using Application;
using Application.Dtos.Categories;

namespace BlazorUI.Services.Category;

public interface ICategoryService
{
    Task<ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>> GetAllCategories();
    Task<ApplicationResponse<CategoryResponseDto>> GetCategoryById(int categoryId);
    Task<ApplicationResponse<CategoryResponseDto>> CreateCategory(CategoryCreateDto category);
    Task<ApplicationResponse<CategoryResponseDto>> UpdateCategory(CategoryUpdateDto category);
    Task<ApplicationResponse<CategoryResponseDto>> DeleteCategory(int categoryId);
}

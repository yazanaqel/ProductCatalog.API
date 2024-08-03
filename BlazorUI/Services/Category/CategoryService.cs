using Application;
using Application.Dtos.Categories;
using System.Net.Http.Json;

namespace BlazorUI.Services.Category;

public class CategoryService(HttpClient httpClient) : ICategoryService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationResponse<CategoryResponseDto>> CreateCategory(CategoryCreateDto category)
    {
        var response = new ApplicationResponse<CategoryResponseDto>();

        try
        {
            var result = await _httpClient.PostAsJsonAsync("api/Category/CreateCategory",category);

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<CategoryResponseDto>>();

            if(data is not null)
            {
                return data;
            }

        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }

    public async Task<ApplicationResponse<CategoryResponseDto>> DeleteCategory(int categoryId)
    {
        var response = new ApplicationResponse<CategoryResponseDto>();

        try
        {
            var result = await _httpClient.DeleteAsync($"api/Category/DeleteCategory?categoryId={categoryId}");

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<CategoryResponseDto>>();

            if(data is not null)
            {
                return data;
            }

        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }

    public async Task<ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>> GetAllCategories()
    {
        var response = new ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>();

        try
        {
            response = await _httpClient.GetFromJsonAsync<ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>>
                      ("/api/Category/GetAllCategories");

            if(response is not null)
            {
                return response;
            }
        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }

    public async Task<ApplicationResponse<CategoryResponseDto>> GetCategoryById(int categoryId)
    {
        var response = new ApplicationResponse<CategoryResponseDto>();

        try
        {
            response = await _httpClient.GetFromJsonAsync<ApplicationResponse<CategoryResponseDto>>
                        ($"/api/Category/GetCategoryById?categoryId={categoryId}");

            if(response is not null)
            {
                return response;
            }
        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }

    public async Task<ApplicationResponse<CategoryResponseDto>> UpdateCategory(CategoryUpdateDto category)
    {
        var response = new ApplicationResponse<CategoryResponseDto>();

        try
        {
            var result = await _httpClient.PutAsJsonAsync("api/Category/UpdateCategory",category);

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<CategoryResponseDto>>();

            if(data is not null)
            {
                return data;
            }

        }
        catch(Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }

        return response;
    }

}
public class CategoriesResponseDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
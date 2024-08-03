using Application;
using Application.Dtos.Products;
using System.Net.Http.Json;

namespace BlazorUI.Services.Product;

public class ProductService(HttpClient httpClient) : IProductService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationResponse<ProductResponseDto>> CreateProduct(ProductCreateDto product)
    {
        var response = new ApplicationResponse<ProductResponseDto>();

        try
        {
            var result = await _httpClient.PostAsJsonAsync("api/Product/CreateProduct",product);

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<ProductResponseDto>>();

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

    public async Task<ApplicationResponse<ProductResponseDto>> DeleteProduct(int productId)
    {
        var response = new ApplicationResponse<ProductResponseDto>();

        try
        {
            var result = await _httpClient.DeleteAsync($"api/Product/DeleteProduct?productId={productId}");

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<ProductResponseDto>>();

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

    public async Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> GetAllProducts()
    {
        var response = new ApplicationResponse<IReadOnlyList<ProductsResponseDto>>();

        try
        {
            response = await _httpClient.GetFromJsonAsync<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>
                      ("/api/Product/GetAllProducts");

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

    public async Task<ApplicationResponse<ProductResponseDto>> GetProductById(int productId)
    {
        var response = new ApplicationResponse<ProductResponseDto>();

        try
        {
            response = await _httpClient.GetFromJsonAsync<ApplicationResponse<ProductResponseDto>>
                        ($"/api/Product/GetProductById?productId={productId}");

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

    public async Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> GetProductsByCategory(int categoryId)
    {
        var response = new ApplicationResponse<IReadOnlyList<ProductsResponseDto>>();

        try
        {
            response = await _httpClient.GetFromJsonAsync<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>
                      ($"/api/Product/GetProductsByCategory?categoryId={categoryId}");

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

    public async Task<ApplicationResponse<ProductResponseDto>> UpdateProduct(ProductUpdateDto product)
    {
        var response = new ApplicationResponse<ProductResponseDto>();

        try
        {
            var result = await _httpClient.PutAsJsonAsync("api/Product/UpdateProduct",product);

            var data = await result.Content.ReadFromJsonAsync<ApplicationResponse<ProductResponseDto>>();

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
public class ProductsResponseDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
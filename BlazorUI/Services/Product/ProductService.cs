using Application;
using System.Net.Http.Json;

namespace BlazorUI.Services.Product;

public class ProductService(HttpClient httpClient) : IProductService
{
    private readonly HttpClient _httpClient = httpClient;

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
}
public class ProductsResponseDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
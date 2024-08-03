using Application.Application.Abstractions;
using Application.Constants;
using Application.Dtos.Products;
using Application.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Queries;

public record GetAllProductsQuery() : IRequest<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>;

public class GetAllProductsHandler(IDbContext dbContext) : IRequestHandler<GetAllProductsQuery,ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>
{

    private readonly IDbContext _dbContext = dbContext;

    public async Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> Handle(GetAllProductsQuery request,CancellationToken cancellationToken)
    {

        var applicationResponse = new ApplicationResponse<IReadOnlyList<ProductsResponseDto>>();

        IQueryable<Product> products = _dbContext.Products.AsNoTracking();

        if(!products.Any())
        {
            applicationResponse.Message = CustomConstants.NotFound.NoProducts;
            return applicationResponse;
        }

        var productsList = await products.ToListAsync();

        var result = productsList.ConvertAll(product => new ProductsResponseDto(product));

        applicationResponse.Data = result.AsReadOnly();
        applicationResponse.Success = true;

        return applicationResponse;
    }
}
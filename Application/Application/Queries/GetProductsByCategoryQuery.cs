using Application.Application.Abstractions;
using Application.Constants;
using Application.Dtos.Products;
using Application.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Queries;

public record GetProductsByCategoryQuery(int categoryId) : IRequest<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>;

public class GetProductsByCategoryHandler(IDbContext dbContext) : IRequestHandler<GetProductsByCategoryQuery, ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> {

    private readonly IDbContext _dbContext = dbContext;

    public async Task<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken) {

        var applicationResponse = new ApplicationResponse<IReadOnlyList<ProductsResponseDto>>();

        IQueryable<Product> products = _dbContext.Products
                                  .Join(_dbContext.ProductCategories,
                                        p => p.ProductId,
                                        pc => pc.ProductId,
                                        (p, pc) => new { p, pc })
                                  .Where(joined => joined.pc.CategoryId == request.categoryId)
                                  .Select(joined => joined.p)
                                  .AsNoTracking();

        if (!products.Any()) {
            applicationResponse.Message = CustomConstants.NotFound.NoProducts;
            return applicationResponse;
        }

        var categoriesList = await products.ToListAsync();

        var result = categoriesList.ConvertAll(product => new ProductsResponseDto(product));

        applicationResponse.Data = result.AsReadOnly();
        applicationResponse.Success = true;

        return applicationResponse;
    }
}
using Application.Application.Abstractions;
using Application.Constants;
using Application.Dtos.Categories;
using Application.Entities.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Queries;
public record GetAllCategoriesQuery() : IRequest<ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>>;

public class GetAllCategoriesHandler(IDbContext dbContext) : IRequestHandler<GetAllCategoriesQuery, ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>> {

    private readonly IDbContext _dbContext = dbContext;

    public async Task<ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) {

        var applicationResponse = new ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>();

        IQueryable<Category> categories = _dbContext.Categories.AsNoTracking();

        if (!categories.Any()) {
            applicationResponse.Message = CustomConstants.NotFound.NoCategories;
            return applicationResponse;
        }

        var categoriesList = await categories.ToListAsync();

        var result = categoriesList.ConvertAll(category => new CategoriesResponseDto(category));

        applicationResponse.Data = result.AsReadOnly();
        applicationResponse.Success = true;

        return applicationResponse;
    }
}
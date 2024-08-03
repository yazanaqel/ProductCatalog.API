using Application.Application.Abstractions;
using Application.Constants;
using Application.Dtos.Categories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Queries;

public record GetCategoryByIdQuery(int categoryId) : IRequest<ApplicationResponse<CategoryResponseDto>>;

public class GetCategoryByIdHandler(IDbContext dbContext,IMapper mapper) : IRequestHandler<GetCategoryByIdQuery,ApplicationResponse<CategoryResponseDto>>
{

    private readonly IDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<CategoryResponseDto>> Handle(GetCategoryByIdQuery request,CancellationToken cancellationToken)
    {

        var applicationResponse = new ApplicationResponse<CategoryResponseDto>();

        var category = await _dbContext.Categories
            .Where(c => c.CategoryId == request.categoryId).AsNoTracking().FirstOrDefaultAsync();

        if(category is null)
        {
            applicationResponse.Message = CustomConstants.NotFound.NoCategories;
            return applicationResponse;
        }

        var response = _mapper.Map<CategoryResponseDto>(category);

        applicationResponse.Data = response;
        applicationResponse.Success = true;

        return applicationResponse;
    }
}
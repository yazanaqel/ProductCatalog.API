using Application.Application.Abstractions;
using Application.Constants;
using Application.Dtos.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Queries;
public record GetProductByIdQuery(int productId) : IRequest<ApplicationResponse<ProductResponseDto>>;

public class GetProductByIdHandler(IDbContext dbContext,IMapper mapper) : IRequestHandler<GetProductByIdQuery,ApplicationResponse<ProductResponseDto>>
{

    private readonly IDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<ProductResponseDto>> Handle(GetProductByIdQuery request,CancellationToken cancellationToken)
    {

        var applicationResponse = new ApplicationResponse<ProductResponseDto>();

        var product = await _dbContext.Products
            .Where(c => c.ProductId == request.productId).AsNoTracking().FirstOrDefaultAsync();

        if(product is null)
        {
            applicationResponse.Message = CustomConstants.NotFound.NoProducts;
            return applicationResponse;
        }

        var response = _mapper.Map<ProductResponseDto>(product);

        applicationResponse.Data = response;
        applicationResponse.Success = true;

        return applicationResponse;
    }
}
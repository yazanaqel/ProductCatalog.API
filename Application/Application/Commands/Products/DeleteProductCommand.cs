using Application.Application.Extensions;
using Application.Dtos.Products;
using Application.Entities.Products;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Products;

public record DeleteProductCommand(int productId) : BaseRequest, IRequest<ApplicationResponse<ProductResponseDto>>;

public class DeleteProductHandler(IProductService productService,IMapper mapper) : IRequestHandler<DeleteProductCommand,ApplicationResponse<ProductResponseDto>>
{
    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<ProductResponseDto>> Handle(DeleteProductCommand request,CancellationToken cancellationToken)
    {

        var result = await _productService.DeleteProduct(request.productId,request.UserId);

        var response = _mapper.Map<ApplicationResponse<ProductResponseDto>>(result);

        return response;
    }
}
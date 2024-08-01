using Application.Application.Extensions;
using Application.Dtos.Products;
using Application.Entities.Products;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Products;
public record UpdateProductCommand(ProductUpdateDto Dto) : BaseRequest, IRequest<ApplicationResponse<ProductResponseDto>>;

public class UpdateProductHandler(IProductService productService,IMapper mapper) : IRequestHandler<UpdateProductCommand,ApplicationResponse<ProductResponseDto>>
{

    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<ProductResponseDto>> Handle(UpdateProductCommand request,CancellationToken cancellationToken)
    {

        var updateProduct = _mapper.Map<Product>(request.Dto);

        updateProduct.UserId = request.UserId;

        var result = await _productService.UpdateProduct(updateProduct);

        var response = _mapper.Map<ApplicationResponse<ProductResponseDto>>(result);

        return response;
    }
}

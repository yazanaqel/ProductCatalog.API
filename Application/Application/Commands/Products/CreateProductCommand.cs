using Application.Application.Extensions;
using Application.Dtos.Products;
using Application.Entities.Products;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Products;

public record CreateProductCommand(ProductCreateDto Dto) : BaseRequest, IRequest<ApplicationResponse<ProductResponseDto>>;

public class CreateProductHandler(IProductService productService, IMapper mapper) : IRequestHandler<CreateProductCommand, ApplicationResponse<ProductResponseDto>> {


    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<ProductResponseDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken) {

        var newProduct = _mapper.Map<Product>(request.Dto);

        newProduct.UserId = request.UserId;

        var result = await _productService.CreateProduct(newProduct, request.Dto.CategoriesList);

        var response = _mapper.Map<ApplicationResponse<ProductResponseDto>>(result);

        return response;
    }
}
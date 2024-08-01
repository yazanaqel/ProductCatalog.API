using Application.Application.Extensions;
using Application.Dtos.Categories;
using Application.Entities.Categories;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Categories;

public record DeleteCategoryCommand(int categoryId) : BaseRequest, IRequest<ApplicationResponse<CategoryResponseDto>>;

public class DeleteCategoryHandler(ICategoryService categoryService,IMapper mapper) : IRequestHandler<DeleteCategoryCommand,ApplicationResponse<CategoryResponseDto>>
{

    private readonly ICategoryService _categoryService = categoryService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<CategoryResponseDto>> Handle(DeleteCategoryCommand request,CancellationToken cancellationToken)
    {

        var result = await _categoryService.DeleteCategory(request.categoryId,request.UserId);

        var response = _mapper.Map<ApplicationResponse<CategoryResponseDto>>(result);

        return response;
    }
}
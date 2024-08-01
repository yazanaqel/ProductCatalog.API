using Application.Application.Extensions;
using Application.Dtos.Categories;
using Application.Entities.Categories;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Categories;

public record UpdateCategoryCommand(CategoryUpdateDto Dto) : BaseRequest, IRequest<ApplicationResponse<CategoryResponseDto>>;

public class UpdateCategoryHandler(ICategoryService categoryService, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, ApplicationResponse<CategoryResponseDto>> {

    private readonly ICategoryService _categoryService = categoryService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<CategoryResponseDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken) {

        var updateCategory = _mapper.Map<Category>(request.Dto);

        updateCategory.UserId = request.UserId;

        var result = await _categoryService.UpdateCategory(updateCategory);

        var response = _mapper.Map<ApplicationResponse<CategoryResponseDto>>(result);

        return response;
    }
}
using Application.Application.Extensions;
using Application.Dtos.Categories;
using Application.Entities.Categories;
using AutoMapper;
using MediatR;

namespace Application.Application.Commands.Categories;

public record CreateCategoryCommand(CategoryCreateDto Dto) : BaseRequest, IRequest<ApplicationResponse<CategoryResponseDto>>;

public class RegisterUserHandler(ICategoryService categoryService, IMapper mapper) : IRequestHandler<CreateCategoryCommand, ApplicationResponse<CategoryResponseDto>> {

    private readonly ICategoryService _categoryService = categoryService;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationResponse<CategoryResponseDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken) {

        var newCategory = _mapper.Map<Category>(request.Dto);

        newCategory.UserId = request.UserId;

        var result = await _categoryService.CreateCategory(newCategory);

        var response = _mapper.Map<ApplicationResponse<CategoryResponseDto>>(result);

        return response;
    }
}
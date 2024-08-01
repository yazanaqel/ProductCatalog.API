using Application;
using Application.Application.Commands.Categories;
using Application.Application.Queries;
using Application.Dtos.Categories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;


    [AllowAnonymous]
    [HttpGet("GetAllCategories")]
    public async Task<ActionResult<ApplicationResponse<IReadOnlyList<CategoriesResponseDto>>>> GetAllCategories() {
        var response = await _mediator.Send(new GetAllCategoriesQuery());

        return response.Success ? Ok(response) : NotFound(response.Message);
    }

    [HttpPost("CreateCategory")]
    public async Task<ActionResult<ApplicationResponse<CategoryResponseDto>>> CreateCategory(CategoryCreateDto dto) {

        var response = await _mediator.Send(new CreateCategoryCommand(dto));
        return Ok(response);
    }

    [HttpPut("UpdateCategory")]
    public async Task<ActionResult<ApplicationResponse<CategoryResponseDto>>> UpdateCategory(CategoryUpdateDto dto) {

        var response = await _mediator.Send(new UpdateCategoryCommand(dto));
        return Ok(response);
    }

    [HttpDelete("DeleteCategory")]
    public async Task<ActionResult<ApplicationResponse<CategoryResponseDto>>> DeleteCategory([Required] int categoryId) {

        var response = await _mediator.Send(new DeleteCategoryCommand(categoryId));
        return Ok(response);
    }
}

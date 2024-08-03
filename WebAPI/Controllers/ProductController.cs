using Application;
using Application.Application.Commands.Products;
using Application.Application.Queries;
using Application.Dtos.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [AllowAnonymous]
    [HttpGet("GetProductsByCategory")]
    public async Task<ActionResult<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>> GetProductsByCategory([Required] int categoryId)
    {
        var response = await _mediator.Send(new GetProductsByCategoryQuery(categoryId));

        return Ok(response);
    }
    [AllowAnonymous]
    [HttpGet("GetAllProducts")]
    public async Task<ActionResult<ApplicationResponse<IReadOnlyList<ProductsResponseDto>>>> GetAllProducts()
    {
        var response = await _mediator.Send(new GetAllProductsQuery());

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("GetProductById")]
    public async Task<ActionResult<ApplicationResponse<ProductResponseDto>>> GetProductById([Required] int productId)
    {
        var response = await _mediator.Send(new GetProductByIdQuery(productId));

        return Ok(response);
    }
    [HttpPost("CreateProduct")]
    public async Task<ActionResult<ApplicationResponse<ProductResponseDto>>> CreateProduct(ProductCreateDto dto)
    {

        var response = await _mediator.Send(new CreateProductCommand(dto));
        return Ok(response);
    }

    [HttpPut("UpdateProduct")]
    public async Task<ActionResult<ApplicationResponse<ProductResponseDto>>> UpdateProduct(ProductUpdateDto dto)
    {

        var response = await _mediator.Send(new UpdateProductCommand(dto));
        return Ok(response);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<ActionResult<ApplicationResponse<ProductResponseDto>>> DeleteProduct([Required] int productId)
    {

        var response = await _mediator.Send(new DeleteProductCommand(productId));
        return Ok(response);
    }
}

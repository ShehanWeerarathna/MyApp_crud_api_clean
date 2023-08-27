﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.DTOs;
using MyApp.Application.Queries;
using MyApp.Application.Services.Interfaces;

namespace MyApp.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
   
    private readonly IMediator _mediator;
    
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
       // ProductDto? productDto = await _productService.GetProductByIdAsync(id);
        ProductPageDataResponse? productPageDataResponse = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(productPageDataResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        //List<ProductDto>? productDtos = await _productService.GetProductsAsync();
        List<ProductDto>? productDtos = await _mediator.Send(new GetProductsQuery());
        return Ok(productDtos);
    }
    [HttpGet]
    public async Task<IActionResult> GetProductPageDataAsync()
    {
        ProductPageDataResponse? productPageDataResponse = await _mediator.Send(new GetProductPageDataQuery());
        return Ok(productPageDataResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        List<CategoryDto>? categoryDtos = await _mediator.Send(new GetCategoriesQuery());
        return Ok(categoryDtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductDto productDto)
    {
        var result = await _mediator.Send(new CreateProductCommand(productDto));
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync(ProductDto productDto)
    {
        var result = await _mediator.Send(new UpdateProductCommand(productDto));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        return Ok(result);
    }
}
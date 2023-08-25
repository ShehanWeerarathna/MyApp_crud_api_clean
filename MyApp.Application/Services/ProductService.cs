using AutoMapper;
using MyApp.Application.DTOs;
using MyApp.Application.Services.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Repositories.Interfaces;

namespace MyApp.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        Product? product = await _productRepository.GetProductByIdAsync(id);
        ProductDto? productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
    
    public async Task<List<ProductDto>> GetProductsAsync()
    {
        List<Product>? products = await _productRepository.GetProductsAsync();
        List<ProductDto>? productDtos = _mapper.Map<List<ProductDto>>(products);
        return productDtos;
    }
}
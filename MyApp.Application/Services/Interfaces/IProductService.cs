using MyApp.Application.DTOs;

namespace MyApp.Application.Services.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetProductByIdAsync(int id);
}
namespace MyApp.Application.DTOs;

public record ProductListPageDataResponse(List<ProductDto> products, List<SelectDto> categories);
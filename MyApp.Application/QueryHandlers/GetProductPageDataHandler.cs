using AutoMapper;
using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Queries;
using MyApp.Infrastructure.Repositories.Interfaces;

namespace MyApp.Application.QueryHandlers
{
    public class GetProductPageDataHandler : IRequestHandler<GetProductPageDataQuery, ProductPageDataResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductPageDataHandler(IProductRepository productRepository, IMapper mapper )
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductPageDataResponse> Handle(GetProductPageDataQuery request, CancellationToken cancellationToken)
        {
            ProductPageDataResponse productPageDataResponse = new ProductPageDataResponse();
            var categories = await _productRepository.GetCategoriesAsync();
  
            List<SelectDto>? selectDtos = categories.Select(c => new SelectDto { Value = c.Id, Label = c.Name }).ToList();
            productPageDataResponse.Categories = selectDtos;
           return productPageDataResponse;
        }
    }
}

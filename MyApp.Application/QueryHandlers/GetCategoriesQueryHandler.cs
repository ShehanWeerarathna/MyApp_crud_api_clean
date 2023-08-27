using AutoMapper;
using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Queries;
using MyApp.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.QueryHandlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetCategoriesQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            var categories = await _productRepository.GetCategoriesAsync();
            categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            
            return categoriesDto;
        }
    }
}

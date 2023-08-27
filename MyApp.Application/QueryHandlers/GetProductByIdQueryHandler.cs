﻿using AutoMapper;
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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductPageDataResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<ProductPageDataResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            
            var categories = await _productRepository.GetCategoriesAsync();

            ProductDto? productDto = null;
            if (request.Id > 0)
            {
                var product = await _productRepository.GetProductByIdAsync(request.Id);
                productDto = _mapper.Map<ProductDto>(product);
            }
           
      
            List<SelectDto>? selectDtos = categories.Select(c => new SelectDto { Value = c.Id, Label = c.Name }).ToList();
            ProductPageDataResponse productPageDataResponse = new ProductPageDataResponse
            {
                Product = productDto,
                Categories = selectDtos
            };

            return productPageDataResponse;
        }
    }
}
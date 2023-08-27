using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductPageDataResponse>;
    public record GetProductPageDataQuery() : IRequest<ProductPageDataResponse>;
    public record GetCategoriesQuery() : IRequest<List<CategoryDto>>;
    public record GetProductsQuery() : IRequest<List<ProductDto>>;
}

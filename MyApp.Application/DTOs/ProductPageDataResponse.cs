using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class ProductPageDataResponse
    {
        public List<SelectDto>? Categories { get; set; }
        public ProductDto? Product { get; set; }
    }
}

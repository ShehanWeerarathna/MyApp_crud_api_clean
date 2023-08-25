using AutoMapper;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Mappings;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
    }
}
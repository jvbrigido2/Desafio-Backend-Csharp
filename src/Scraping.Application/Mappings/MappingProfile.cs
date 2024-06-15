using AutoMapper;
using Scraping.Application.DTOs;
using Scraping.Domain.Entities;

namespace Scraping.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<FoodItem, FoodItemDto>();
        CreateMap<Component, ComponentDto>();
    }
}

using AutoMapper;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Profiles;

public class FoodProfiles:Profile
{
    public FoodProfiles(){
        CreateMap<Food, FoodDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.TagNames, opt => opt.MapFrom(src => src.Tags.Select(t => t.Name).ToList()));
        CreateMap<NewFoodDto, Food>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore()) // Will be handled separately in controller
            .ForMember(dest => dest.Category, opt => opt.Ignore()); //set Category in controller
    }
    
}
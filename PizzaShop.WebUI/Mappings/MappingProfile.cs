using AutoMapper;
using PizzaShop.Domain.Entities;
using PizzaShop.WebUI.Models;

namespace PizzaShop.WebUI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pizza, PizzaViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => 
                    string.Join(", ", src.PizzaIngredients.Select(x => x.Ingredient.Name))));
        }
    }
}

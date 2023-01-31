using AutoMapper;
using FoodDiary.Data.Entities;
using FoodDiary.ViewModels;

namespace FoodDiary.Data
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();           
            
            CreateMap<Dish, DishViewModel>() 
                .ReverseMap()
                .ForMember(m => m.ResourseSpecificationId, opt => opt.Ignore());

            CreateMap<ResourseSpecification, ResourseSpecificationViewModel>()
                .ReverseMap();
                

            CreateMap<CompositionItem, CompositionItemViewModel>()
                .ReverseMap()
                //.ForMember(m => m.ProductId, opt => opt.Ignore())
                .ForMember(m => m.Product, opt => opt.Ignore());

            CreateMap<DishValue, DishValueViewModel>()
                .ReverseMap();         

            
        }

    }
}



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
                .ReverseMap();
            
            CreateMap<ResourseSpecification, ResourseSpecificationViewModel>()
                .ReverseMap();

            CreateMap<CompositionItem, CompositionItemViewModel>()
                .ReverseMap();
            CreateMap<DishValue, DishValueViewModel>()
                .ReverseMap();         

            
        }

    }
}



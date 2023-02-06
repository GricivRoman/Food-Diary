using AutoMapper;
using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.Food;
using FoodDiary.ViewModels.User;

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
                .ReverseMap()
                .ForMember(m => m.Product, opt => opt.Ignore());

            CreateMap<DishValue, DishValueViewModel>()
                .ReverseMap();

            CreateMap<User, UserViewModel>()
                .ForMember(m=> m.Password, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<WeightCondition, WeightConditionViewModel>()
                .ReverseMap();
            CreateMap<Target, TargetViewModel>()
                .ReverseMap();
            CreateMap<DailyRate, DailyRateViewModel>()
                .ReverseMap();
            CreateMap<Meal, MealViewModel>()
                .ReverseMap();
            CreateMap<MealItem, MealItemViewModel>()
                .ReverseMap();
        }

    }
}



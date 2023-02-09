using FoodDiary.ViewModels.Food;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.EnergyValueCalculator
{
    public interface IEnergyValueCalculatorService
    {
        DishValueViewModel CalculateDishValue(ResourseSpecificationViewModel resourseSpecification);
        
        Task<ICollection<MealViewModel>> GetMealsWithValueAsync(ICollection<MealViewModel> meals);


    }
}
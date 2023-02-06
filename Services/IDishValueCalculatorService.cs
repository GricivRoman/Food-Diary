using FoodDiary.ViewModels.Food;

namespace FoodDiary.Services
{
    public interface IDishValueCalculatorService
    {
        DishValueViewModel CalculateDishValue(ResourseSpecificationViewModel resourseSpecification);
    }
}
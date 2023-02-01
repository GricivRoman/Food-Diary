using FoodDiary.ViewModels;

namespace FoodDiary.Services
{
    public interface IDishValueCalculatorService
    {
        DishValueViewModel CalculateDishValue(ResourseSpecificationViewModel resourseSpecification);
    }
}
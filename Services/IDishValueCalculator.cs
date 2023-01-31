using FoodDiary.ViewModels;

namespace FoodDiary.Services
{
    public interface IDishValueCalculator
    {
        DishValueViewModel CalculateDishValue(ResourseSpecificationViewModel resourseSpecification);
    }
}
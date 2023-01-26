using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels
{
    public class ResourseSpecificationViewModel
    {
        public ICollection<CompositionItemViewModel>? Composition { get; set; }
        
        public double? OutputDishWeightG { get; set; }

        public DishValueViewModel? DishValue { get; set; }
    }
}

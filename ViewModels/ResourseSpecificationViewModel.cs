using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels
{
    public class ResourseSpecificationViewModel
    {
        public int Id { get; set; }
        public ICollection<CompositionItemViewModel>? Composition { get; set; }
                
        public double? OutputDishWeightG { get; set; }

        public DishValueViewModel? DishValue { get; set; }
    }
}

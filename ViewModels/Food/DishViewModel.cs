using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels.Food
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string DishName { get; set; }

        public ResourseSpecificationViewModel ResourseSpecification { get; set; }

    }
}

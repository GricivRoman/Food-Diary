using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.Food;

namespace FoodDiary.ViewModels.User
{
    public class MealItemViewModel
    {
        public int Id { get; set; }       
        public DishViewModel Dish { get; set; }
        public int DishId { get; set; }

        public double DishWeightG { get; set; }
    }
}

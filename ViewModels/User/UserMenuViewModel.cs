using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.Food;

namespace FoodDiary.ViewModels.User
{
    public class UserMenuViewModel
    {
        public int Id { get; set; }        
        public ICollection<DishViewModel>? Dishes { get; set; }
    }
}

using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels.User
{
    public class MealViewModel
    {
        public int Id { get; set; }
        
        public DateTime MealTime { get; set; }

        public ICollection<MealItemViewModel> MealItems { get; set; }

        public MealValueViewModel MealValue { get; set; }
    }
}

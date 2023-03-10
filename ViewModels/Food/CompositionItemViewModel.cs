using FoodDiary.Data.Entities;

namespace FoodDiary.ViewModels.Food
{
    public class CompositionItemViewModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }

        public double ProductWeightG { get; set; }
    }
}

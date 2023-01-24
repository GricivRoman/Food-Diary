namespace FoodDiary.Data.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public User User { get; set; }
        
        public DateTime MealTime { get; set; }

        public ICollection<MealItem> MealItems { get; set; }
    }
}

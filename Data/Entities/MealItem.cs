namespace FoodDiary.Data.Entities
{
    public class MealItem
    {
        public int Id { get; set; }
        public Meal Meal { get; set; }
        public int MealId { get; set; }
       

        public Dish Dish { get; set; }
        public int DishId { get; set; }
        
        public double DishWeightG { get; set; }

    }
}

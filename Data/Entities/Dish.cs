namespace FoodDiary.Data.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        string DishName { get; set; }

        public ICollection<Specification> Specification { get; set; }

        
    }
}

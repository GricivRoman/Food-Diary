namespace FoodDiary.Data.Entities
{
    public class UserMenu
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }


        public ICollection<Dish> Dishes { get; set; }
    }
}

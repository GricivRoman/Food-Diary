namespace FoodDiary.Data.Entities
{
    public class Sex
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }

    }
}

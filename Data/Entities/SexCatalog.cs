namespace FoodDiary.Data.Entities
{
    public class SexCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }

    }
}

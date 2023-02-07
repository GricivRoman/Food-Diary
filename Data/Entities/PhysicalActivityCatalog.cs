namespace FoodDiary.Data.Entities
{
    public class PhysicalActivityCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PhysicalActivityMultiplier { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}

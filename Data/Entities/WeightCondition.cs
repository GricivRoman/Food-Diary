namespace FoodDiary.Data.Entities
{
    public class WeightCondition
    {
        public int Id { get; set; }
        public User User { get; set; }
        
        public DateTime Date { get; set; }
        public double BodyWeight { get; set; }
    }
}

namespace FoodDiary.Data.Entities
{
    public class CompositionItem
    {
        public int Id { get; set; }
        public Specification Specification { get; set; }

        public Product Product { get; set; }


        public double ProductWeightG { get; set; }
    }
}

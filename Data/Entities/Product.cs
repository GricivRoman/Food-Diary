namespace FoodDiary.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public double Calories { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
    }
}

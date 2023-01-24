namespace FoodDiary.Data.Entities
{
    public class Specification
    {
        public int Id { get; set; }

        public Dish Dish { get; set; }
        public int DishId { get; set; }

        public ICollection<CompositionItem> Composition { get; set; }

        public double OutputDishWeightG { get; set; }

        public DishValue DishValue { get; set; }
        public bool MainSpecification { get; set; }
    }
}

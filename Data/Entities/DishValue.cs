namespace FoodDiary.Data.Entities
{
    public class DishValue
    {
        public int Id { get; set; }
        public ResourseSpecification ResourseSpecification { get; set; }
        public int ResourseSpecificationId { get; set; }

        public double Calories { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
    }
}

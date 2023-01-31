namespace FoodDiary.Data.Entities
{
    public class CompositionItem
    {
        public int Id { get; set; }
        public ResourseSpecification ResourseSpecification { get; set; }
        public int ResourseSpecificationId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }


        public double ProductWeightG { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.Data.Entities
{
    public class ResourseSpecification
    {
        public int Id { get; set; }
        
        public Dish Dish { get; set; }
        public int DishId { get; set; }

        public ICollection<CompositionItem> Composition { get; set; }

        public double OutputDishWeightG { get; set; }

        public DishValue DishValue { get; set; }

        public int DishValueId { get; set; }



    }
}

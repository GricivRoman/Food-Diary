using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.Data.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string DishName { get; set; }

        public ICollection<UserMenu>? UserMenu { get; set; }
        public int? UserMenuId { get; set; }

        public ResourseSpecification ResourseSpecification { get; set; }
        
        [ForeignKey(nameof(ResourseSpecification))]
        public int ResourseSpecificationId { get; set; }


    }
}

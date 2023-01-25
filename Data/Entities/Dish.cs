namespace FoodDiary.Data.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        string DishName { get; set; }

        public ICollection<UserMenu> UserMenu { get; set; }
        public int UserMenuId { get; set; }

        public ResourseSpecification ResourseSpecification { get; set; }
        public int ResourseSpecificationId { get; set;}       


    }
}

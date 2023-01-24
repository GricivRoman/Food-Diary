using Microsoft.AspNetCore.Identity;

namespace FoodDiary.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public ICollection<WeightCondition> WeightConditions { get; set; }

        public ICollection<Target> Targets { get; set; }
        public UserMenu UserMenu { get; set; }

        public ICollection<Meal>  Meals { get; set; }
    }
}

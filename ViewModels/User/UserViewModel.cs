using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.Catalogs;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.ViewModels.User
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
       
        public string? Password { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public double Height { get; set; }

        public UserMenu? UserMenu { get; set; }

        public int? UserMenuId { get; set; }

        public string? Gender { get; set; }

        public ICollection<WeightConditionViewModel>? WeightConditions { get; set; }

        public ICollection<TargetViewModel>? Targets { get; set; }

        public ICollection<MealViewModel>? Meals { get; set; }

        public SexCatalogViewModel? Sex { get; set; }
        public int? SexId { get; set; }
        public PhysicalActivityCatalogViewModel? PhysicalActivity { get; set; }
        public int? PhysicalActivityId { get; set; }
    }
}

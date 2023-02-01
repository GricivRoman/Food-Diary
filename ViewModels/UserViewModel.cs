using FoodDiary.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.ViewModels
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserMenu? UserMenu { get; set; }

        public int? UserMenuId { get; set; }
    }
}

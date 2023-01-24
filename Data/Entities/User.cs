using Microsoft.AspNetCore.Identity;

namespace FoodDiary.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

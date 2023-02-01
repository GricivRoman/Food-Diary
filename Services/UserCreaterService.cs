using FoodDiary.Data;
using FoodDiary.Data.Entities;
using FoodDiary.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FoodDiary.Services
{
    public class UserCreaterService : IUserCreaterService
    {
        private readonly MyAppContext context;
        private readonly UserManager<User> userManager;

        public UserCreaterService(MyAppContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> CreateUserAsync(UserViewModel model)
        {

            if (await userManager.FindByEmailAsync(model.Email) != null)
            {
                return "Пользователь с таким Email уже существует";

            }
            else
            {
                if (await userManager.FindByNameAsync(model.UserName) != null)
                {
                    return "Пользователь с таким именем уже существует";
                }
                else
                {
                    User user = new User()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        UserMenu = new UserMenu()
                    };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result != IdentityResult.Success)
                    {
                        return "Недопустимый пароль";
                    }
                    context.User.Add(user);
                    return "Successful";
                }
            }
        }
    }
}

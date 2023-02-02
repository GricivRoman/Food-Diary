using FoodDiary.ViewModels.User;

namespace FoodDiary.Services
{
    public interface IUserCreaterService
    {
        Task<string> CreateUserAsync(UserViewModel model);
    }
}
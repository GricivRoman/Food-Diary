using FoodDiary.ViewModels;

namespace FoodDiary.Services
{
    public interface IUserCreaterService
    {
        Task<string> CreateUserAsync(UserViewModel model);
    }
}
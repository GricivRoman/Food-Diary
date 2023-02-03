using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator
{
    public interface IUserDailyRateCalculator
    {
        List<Target> GetTargetsWithDailyRate(UserViewModel user);
    }
}
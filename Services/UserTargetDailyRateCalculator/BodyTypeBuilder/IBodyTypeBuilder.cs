using FoodDiary.Data.Entities;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyType;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyTypeFactoryBuilder
{
    public interface IBodyTypeBuilder
    {
        IBodyType GetBodyType(UserViewModel user, Target target);
    }
}
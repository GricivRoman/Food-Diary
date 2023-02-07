using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyType
{
    public interface IBodyType
    {
        DailyRate CalculateDailyRate();        
    }
}

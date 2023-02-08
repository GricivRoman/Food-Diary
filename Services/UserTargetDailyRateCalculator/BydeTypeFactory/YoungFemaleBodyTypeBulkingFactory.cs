using FoodDiary.Data.Entities;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyType;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BydeTypeFactory
{
    public class YoungFemaleBodyTypeBulkingFactory : BodyTypeFactory
    {
        public YoungFemaleBodyTypeBulkingFactory(UserViewModel user, Target target) : base(user, target)
        {
        }

        public override IBodyType GetBodyType()
        {
            return new YoungFemaleBodyTypeBulking(user, target);
        }
    }
}

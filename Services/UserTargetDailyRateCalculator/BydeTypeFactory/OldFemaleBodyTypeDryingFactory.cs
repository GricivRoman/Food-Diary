using FoodDiary.Data.Entities;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyType;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BydeTypeFactory
{
    public class OldFemaleBodyTypeDryingFactory : BodyTypeFactory
    {
        public OldFemaleBodyTypeDryingFactory(UserViewModel user, Target target) : base(user, target)
        {
        }

        public override IBodyType GetBodyType()
        {
            return new OldFemaleBodyTypeDrying(user, target);
        }
    }
}

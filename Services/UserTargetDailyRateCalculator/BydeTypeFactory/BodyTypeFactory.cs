using FoodDiary.Data.Entities;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyType;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BydeTypeFactory
{
    public abstract class BodyTypeFactory : IBodyTypeFactory
    {
        protected readonly UserViewModel user;
        protected readonly Target target;

        public BodyTypeFactory(UserViewModel user, Target target)
        {
            this.user = user;
            this.target = target;
        }
        public abstract IBodyType GetBodyType();



    }
}

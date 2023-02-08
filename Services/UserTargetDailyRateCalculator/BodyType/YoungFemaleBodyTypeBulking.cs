using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyType
{
    public class YoungFemaleBodyTypeBulking : BodyType
    {
        public YoungFemaleBodyTypeBulking(UserViewModel user, Target target) : base(user, target)
        {
        }

        protected override double ProteinMultiplier => 1.5;

        protected override double FatMultiplier => 1.35;

        protected override double NormalBodyMassIndex => 21;

        protected override double VeightDeltaValue => 22;

        protected override double CalculateBasalMetabolicRate()
        {
            double basalMetabolicRate = 9.99 * target.CurrentBodyWeight + 6.25 * user.Height - 4.92 * (double)user.Age - 161;
            return basalMetabolicRate;
        }
    }
}

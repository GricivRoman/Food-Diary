using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyType
{
    public class OldMaleBodyTypeBulking : BodyType
    {
        public OldMaleBodyTypeBulking(UserViewModel user, Target target) : base(user, target)
        {
        }

        protected override double ProteinMultiplier => 2;

        protected override double FatMultiplier => 1.3;

        protected override double NormalBodyMassIndex => 26;

        protected override double VeightDeltaValue => 23;

        protected override double CalculateBasalMetabolicRate()
        {
            double basalMetabolicRate = 9.99 * target.CurrentBodyWeight + 6.25 * user.Height - 4.92 * (double)user.Age + 5;
            return basalMetabolicRate;
        }
    }
}

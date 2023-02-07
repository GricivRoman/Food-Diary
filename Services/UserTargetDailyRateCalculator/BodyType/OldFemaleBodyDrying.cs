using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyType
{
    public class OldFemaleBodyDrying : BodyType
    {
        public OldFemaleBodyDrying(UserViewModel user, Target target) : base(user, target)
        {
        }

        protected override double ProteinMultiplier => 1;

        protected override double FatMultiplier => 2;

        protected override double NormalBodyMassIndex => 22;

        protected override double VeightDeltaValue => 77;

        protected override double CalculateBasalMetabolicRate()
        {
            double basalMetabolicRate = 9.99 * target.CurrentBodyWeight + 6.25 * user.Height - 4.92 * (double)user.Age + 5;
            return basalMetabolicRate;
        }
    }
}

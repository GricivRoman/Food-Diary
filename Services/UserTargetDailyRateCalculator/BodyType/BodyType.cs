using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;


namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyType
{
    public abstract class BodyType : IBodyType
    {
        public BodyType(UserViewModel user, Target target)
        {
            this.user = user;
            this.target = target;
        }
        
        private const int ProteinEnergyValue = 4;
        private const int FatEnergyValue = 9;
        private const int CarbohydrateEnergyValue = 4;
        

        protected abstract double ProteinMultiplier { get; }
        protected abstract double FatMultiplier { get; }
        protected abstract double NormalBodyMassIndex { get; }
        

        protected abstract double VeightDeltaValue { get; }
        // if we need to decrease body weight, we need to burn Fat. If we need to increase body weight, we need to build muscles



        protected readonly UserViewModel user;
        protected readonly Target target;

        protected abstract double CalculateBasalMetabolicRate();
       

        private double CalculateTargetCaloriesRate()
        {
            double currentMetabolicRate = CalculateBasalMetabolicRate() * user.PhysicalActivity.PhysicalActivityMultiplier;

            double targetWeightDelta = target.CurrentBodyWeight - target.TargetBodyWeight;      

            double targetDaysToReach = (target.DateFinish - target.DateStart).TotalDays;        

            double targetCaloriesRate = Math.Round(currentMetabolicRate - (targetWeightDelta*1000 / targetDaysToReach) * VeightDeltaValue, 2);  

            return targetCaloriesRate;
        }

        private double GetBodyWeightForCalculation()
        {
            double normalBodyWeight = NormalBodyMassIndex * Math.Pow(user.Height / 100,2);
            double bodyWeightForCalculation;

            if (normalBodyWeight > target.CurrentBodyWeight)
            {
                bodyWeightForCalculation = target.CurrentBodyWeight;
            }
            else
            {
                bodyWeightForCalculation = normalBodyWeight;
            }

            return bodyWeightForCalculation;
        }


        public DailyRate CalculateDailyRate()
        {
            if (target.CurrentBodyWeight == 0 || user.Height == 0 || user.Age == null || user.Age == 0)
            {
                throw new Exception("Поля не заполнены, либо заполнены нулями");
            }
            else
            {
                DailyRate dailyRate = new DailyRate
                {
                    CaloriesRate = CalculateTargetCaloriesRate(),
                    ProteinRate = Math.Round(GetBodyWeightForCalculation() * ProteinMultiplier,2),
                    FatRate = Math.Round(GetBodyWeightForCalculation() * FatMultiplier,2) 
                };
                dailyRate.CarbohydrateRate = Math.Round((dailyRate.CaloriesRate - dailyRate.ProteinRate * ProteinEnergyValue - dailyRate.FatRate * FatEnergyValue) / CarbohydrateEnergyValue,2);

                return dailyRate;
            }        
        }
    }
}

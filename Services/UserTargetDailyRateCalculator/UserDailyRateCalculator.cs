using AutoMapper;
using FoodDiary.Data.Entities;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator
{
    public class UserDailyRateCalculator : IUserDailyRateCalculator
    {
        private readonly IMapper mapper;

        public UserDailyRateCalculator(IMapper mapper)
        {
            this.mapper = mapper;
        }
        
        //to do Метод, который основываясь на данных пользователя создает класс с видом пользователя.
        //Создать интерфейс с видами пользователей, который имеет в себе метод расчитать дневные нормы
        // для каждого класса, реализующего интерфейс с видами пользователей определить метод расчета дневной нормы.

        public List<Target> GetTargetsWithDailyRate(UserViewModel user)
        {
            var targets = mapper.Map<List<Target>>(user.Targets);
                       

            for (int i = 0; i < user.Targets.Count; i++)
            {
                if (i== user.Targets.Count-1)
                {
                    targets[i].relevance = true;
                }
                else
                {
                    targets[i].relevance = false;
                }

                targets[i].DailyRate = new DailyRate
                {
                    CaloriesRate = 1715,
                    ProteinRate = 160,
                    FatRate = 75,
                    CarbohydrateRate = 100
                };
            }

            return targets;
        }
    }
}

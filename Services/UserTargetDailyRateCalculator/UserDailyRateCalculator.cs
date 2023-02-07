using AutoMapper;
using FoodDiary.Data.Entities;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyType;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyTypeFactoryBuilder;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator
{
    public class UserDailyRateCalculator : IUserDailyRateCalculator
    {
        private readonly IMapper mapper;
        private readonly IBodyTypeBuilder bodyTypeBuilder;

        public UserDailyRateCalculator(IMapper mapper,
            IBodyTypeBuilder bodyTypeBuilder)
        {
            this.mapper = mapper;
            this.bodyTypeBuilder = bodyTypeBuilder;
        }
        
        

        public List<Target> GetTargetsWithDailyRate(UserViewModel user)
        {
            var targets = mapper.Map<List<Target>>(user.Targets);
                       

            for (int i = 0; i < user.Targets.Count; i++)
            {
                if (i== user.Targets.Count-1)
                {
                    targets[i].relevance = true;
                    
                    targets[i].DailyRate = bodyTypeBuilder.GetBodyType(user, targets[i]).CalculateDailyRate();    
                }
                else
                {
                    targets[i].relevance = false;
                }
            }
            return targets;
        }
    }
}

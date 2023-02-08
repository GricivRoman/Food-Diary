using FoodDiary.Data.Entities;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyType;
using FoodDiary.Services.UserTargetDailyRateCalculator.BydeTypeFactory;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.UserTargetDailyRateCalculator.BodyTypeFactoryBuilder
{
    public class BodyTypeBuilder : IBodyTypeBuilder
    {      

        public IBodyType GetBodyType(UserViewModel user, Target target)
        {
            IBodyTypeFactory bodyTypeFactory = GetFactory(user, target);

            return bodyTypeFactory.GetBodyType();
        }


        private IBodyTypeFactory GetFactory(UserViewModel user, Target target)
        {

            if (user.Sex.Name == "Мужчина")
            {
                if (user.Age < 30)
                {
                    if (target.TargetBodyWeight < target.CurrentBodyWeight)
                    {
                        return new YoungMaleBodyTypeDryingFactory(user, target);
                    }
                    else
                    {
                        return new YoungMaleBodyTypeBulkingFactory(user, target);
                    }
                    
                }
                else
                {
                    if (target.TargetBodyWeight < target.CurrentBodyWeight)
                    {
                        return new OldMaleBodyTypeDryingFactory(user, target);
                    }
                    else
                    {
                        return new OldMaleBodyTypeBulkingFactory(user, target);
                    }
                    
                }
            }
            else if (user.Sex.Name == "Женщина")
            {
                if (user.Age < 30)
                {
                    if (target.TargetBodyWeight < target.CurrentBodyWeight)
                    {
                        return new YoungFemaleBodyTypeDryingFactory(user, target);
                    }
                    else
                    {
                        return new YoungFemaleBodyTypeBulkingFactory(user, target);
                    }
                    
                }
                else
                {
                    if (target.TargetBodyWeight < target.CurrentBodyWeight)
                    {
                        return new OldFemaleBodyTypeDryingFactory(user, target);
                    }
                    else
                    {
                        return new OldFemaleBodyTypeBulkingFactory(user, target);
                    }
                    
                }
            }

            throw new Exception("Вид пользователя с заданнми параметрами не найден");
        }


    }
}

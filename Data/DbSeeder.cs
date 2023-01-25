using FoodDiary.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace FoodDiary.Data
{
    public class DbSeeder
    {
        private readonly MyAppContext context;
        private readonly UserManager<User> userManager;

        public DbSeeder(MyAppContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            //context.Database.EnsureDeleted();
            
            User user1 = await userManager.FindByEmailAsync("griciv.roman.st@gmail.com");

            User user = new User()
            {
                //Name = "Roman",
                //Age = 27,
                //Gender = "Male",
                //Email = "griciv.roman.st@gmail.com",
                //UserName = "griciv.roman.st@gmail.com",
                //WeightConditions = new List<WeightCondition>
                //{
                //    new WeightCondition
                //    {
                //        Date = DateTime.UtcNow,
                //        BodyWeight = 95
                //    }
                //},
                //Targets = new List<Target>
                //{
                //    new Target
                //    {
                //        Relevanse = RelevanseType.relevant,
                //        DateStart = DateTime.UtcNow,
                //        DateFinish = DateTime.UtcNow.AddDays(30),
                //        TargetBodyWeight = 90,
                //        DailyRate = new DailyRate
                //        {
                //            CaloriesRate = 1800,
                //            CarbohydrateRate = 90,
                //            FatRate = 75,
                //            ProteinRate = 150
                //        }
                //    }
                //},
                //Meals= new List<Meal>
                //{
                //    new Meal()
                //},
                UserMenu = new UserMenu()
            };

            user.Name = "Roman";
            user.Age = 27;
            user.Gender = "Male";
                user.Email = "griciv.roman.st@gmail.com";
                user.UserName = "griciv.roman.st@gmail.com";
                user.WeightConditions = new List<WeightCondition>
                {
                    new WeightCondition
                    {
                        Date = DateTime.UtcNow,
                        BodyWeight = 95
                    }
                };
                user.Targets = new List<Target>
                {
                    new Target
                    {
                        Relevanse = RelevanseType.relevant,
                        DateStart = DateTime.UtcNow,
                        DateFinish = DateTime.UtcNow.AddDays(30),
                        TargetBodyWeight = 90,
                        DailyRate = new DailyRate
                        {
                            CaloriesRate = 1800,
                            CarbohydrateRate = 90,
                            FatRate = 75,
                            ProteinRate = 150
                        }
                    }
                };
            //user.UserMenu = new UserMenu
            //{

            //};
                


            var result = await userManager.CreateAsync(user, "p@sswOrd777!");

            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create new user in seeder");
            }

            context.User.Add(user);
        }

    }
}

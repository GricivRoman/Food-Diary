using FoodDiary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FoodDiary.Data.Entities;
using AutoMapper;
using FoodDiary.ViewModels.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using FoodDiary.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FoodDiary.Services.UserTargetDailyRateCalculator;

namespace FoodDiary.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    [Produces("application/json")]
    public class UserController:Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IMyAppRepository repository;
        private readonly ILogger<UserController> logger;
        private readonly IUserDailyRateCalculator userDailyRateCalculator;

        public UserController(UserManager<User> userManager,
            IMapper mapper,
            IMyAppRepository repository,
            ILogger<UserController> logger,
            IUserDailyRateCalculator userDailyRateCalculator
            )
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
            this.userDailyRateCalculator = userDailyRateCalculator;
        }

        [HttpPost]
        [Route("getuser")]
        public async Task<IActionResult> GetUser([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await repository.FindUserByNameAsync(model.UserName);
                
                
                               

                return Ok(mapper.Map<UserViewModel>(user));
            }

            return BadRequest("Not found");
        }
        
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("getUserWithIdentity")]
        public async Task<IActionResult> GetUserWithIdentityAsync()
        {
            var user = await repository.FindUserByNameAsync(User.Identity.Name);
            return Ok(mapper.Map<UserViewModel>(user));
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("updateUser")]
        
        public async Task<IActionResult> UpdateUserAsync([FromBody]UserViewModel model)
        {
            
            var user = await repository.FindUserByNameAsync(User.Identity.Name);
                      

            //user = mapper.Map<User>(model); // to do настроить маппинг

            user.Name = model.Name;
            user.Age = model.Age;
            user.Gender= model.Gender;
            user.Height = model.Height;
            user.WeightConditions = mapper.Map<List<WeightCondition>>(model.WeightConditions);
            user.UserMenu = mapper.Map<UserMenu>(model.UserMenu);


            try
            {
                user.Targets = userDailyRateCalculator.GetTargetsWithDailyRate(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
            user.Sex = mapper.Map<SexCatalog>(model.Sex);
            user.PhysicalActivity = mapper.Map<PhysicalActivityCatalog>(model.PhysicalActivity);

            try
            {
                repository.UpdateEntity(user);
                await repository.SaveAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"{DateTime.UtcNow} : {ex}");
                
            }
            
            
            return Ok();

        }

    }
}

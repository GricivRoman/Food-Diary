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

        public UserController(UserManager<User> userManager,
            IMapper mapper,
            IMyAppRepository repository,
            ILogger<UserController> logger
            )
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
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
        [Route("setWeightConditiodn")]
        
        public async Task<IActionResult> UpdateUserAsync([FromBody]UserViewModel model)
        {
            var a = User.Identity.Name;
            var user1 = await repository.FindUserByNameAsync(User.Identity.Name);

            var user = user1;

            //user = mapper.Map<User>(model); // Убрать в маппере лишние поля

            user.WeightConditions = mapper.Map<List<WeightCondition>>(model.WeightConditions);

            try
            {
                repository.UpdateEntity(user); // не создается WeightCondition
                repository.SaveAll();
            }
            catch (Exception ex)
            {
                logger.LogError($"{DateTime.UtcNow} : {ex}");
                
            }
            
            
            return Ok();

        }

    }
}

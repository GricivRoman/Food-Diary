using FoodDiary.Data.Entities;
using FoodDiary.Services;
using FoodDiary.ViewModels;
using FoodDiary.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodDiary.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly IUserCreaterService userCreaterService;

        public AccountController(ILogger<AccountController> logger, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            IConfiguration config, 
            IUserCreaterService userCreaterService)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            this.userCreaterService = userCreaterService;
        }

        [HttpPost]
        [Route("/account/checkin")]
        public async Task<IActionResult> CheckInAsync([FromBody] UserViewModel model)
        {
            string createResult = await userCreaterService.CreateUserAsync(model);

            if(createResult == "Successful")
            {
                return Ok();
            }
            else
            {
                return BadRequest(createResult);
            }
           
        }

        [HttpPost]
        [Route("/account/createtoken")]
        public async Task<IActionResult> CreateTokenAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user!=null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);                    
                    if (result.Succeeded) 
                    {                       
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Token:Issuer"],
                            _config["Token:Audience"],
                            claims, 
                            signingCredentials: creds,
                            expires: DateTime.UtcNow.AddMinutes(120));

                        return Created("", new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }                
            }

            return BadRequest("Неправильный логин или пароль");
        }
        
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FoodDiary.Data;
using FoodDiary.Data.Entities;
using AutoMapper;
using FoodDiary.ViewModels.Food;

namespace FoodDiary.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : Controller
    {       
        private readonly IMyAppRepository repository;
        private readonly ILogger<ProductController> logger;
        private readonly IMapper mapper;

        public ProductController(IMyAppRepository repository, 
            ILogger<ProductController> logger, 
            IMapper mapper)
        {
            
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]ProductViewModel model)
        {
            try
            {
                await repository.FindProductByNameAsync(model.ProductName);
                return BadRequest("Продукт с таким именем уже существует");
            }
            catch
            {
                Product product = mapper.Map<Product>(model);

                await repository.AddEntityAsync(product);
                await repository.SaveAllAsync();

                return Created("", mapper.Map<ProductViewModel>(product));
            }   
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await repository.GetAllProductsAsync();
                return Ok(mapper.Map<List<ProductViewModel>>(result));                
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

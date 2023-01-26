using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FoodDiary.ViewModels;
using FoodDiary.Data;
using FoodDiary.Data.Entities;
using AutoMapper;

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
        public IActionResult Post([FromBody]ProductViewModel model)
        {
            if (repository.FindProductByName(model.ProductName) != null)
            {
                return BadRequest("Продукт с таким именем уже существует");
            }
            else
            {
                Product product = mapper.Map<Product>(model);
                
                repository.AddEntity(product);
                repository.SaveAll();

                return Created("", mapper.Map<ProductViewModel>(product));
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = repository.GetAllProducts();
                return Ok(mapper.Map<List<Product>>(result));
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}

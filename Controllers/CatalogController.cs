using AutoMapper;
using FoodDiary.Data;
using FoodDiary.ViewModels.Catalogs;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class CatalogController : Controller
    {
        private readonly IMyAppRepository repository;
        private readonly IMapper mapper;

        public CatalogController(IMyAppRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("getsexcatalog")]
        public async Task<IActionResult> GetSexCatalogAsync()
        {
            var result = await repository.GetFullSexCatalogAsync();
            return Ok(mapper.Map<List<SexCatalogViewModel>>(result));
            
        }

        [HttpGet]
        [Route("getphysicalactivitycatalog")]
        public async Task<IActionResult> GetPhysicalActivityCatalogAsync()
        {
            var result = await repository.GetFullPhysicalActivityCatalogAsync();
            return Ok(mapper.Map<List<PhysicalActivityCatalogViewModel>>(result));
        }

    }
}

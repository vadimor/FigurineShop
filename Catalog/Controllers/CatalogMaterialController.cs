using Catalog.Models.Response;
using Catalog.Services.Interfaces;
using Catalog.Configurations;
using Catalog.Models.Dtos;
using Catalog.Models.Requests;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AdminPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogMaterialController : Controller
    {
        private ILogger<CatalogBffController> _logger;
        private IOptions<CatalogConfig> _config;
        private ICatalogMaterialService _catalogMaterialService;

        public CatalogMaterialController(
        ILogger<CatalogBffController> logger,
        IOptions<CatalogConfig> config,
        ICatalogMaterialService catalogMaterialService)
        {
            _logger = logger;
            _config = config;
            _catalogMaterialService = catalogMaterialService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<CatalogMaterialDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Materials()
        {
            var result = await _catalogMaterialService.GetMaterialsAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMaterial(GetRequest request)
        {
            var result = await _catalogMaterialService.GetMaterialAsync(request.Id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(AddRequest request)
        {
            var result = await _catalogMaterialService.AddAsync(request.Name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateRequest request)
        {
            var result = await _catalogMaterialService.UpdateAsync(request.Id, request.Name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(RemoveRequest request)
        {
            var result = await _catalogMaterialService.RemoveAsync(request.Id);
            return Ok(result);
        }
    }
}

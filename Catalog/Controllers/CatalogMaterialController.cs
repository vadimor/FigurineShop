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
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("catalog.catalogmaterial")]
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
        [ProducesResponseType(typeof(ItemsListResponse<CatalogMaterialDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Materials()
        {
            var result = await _catalogMaterialService.GetMaterialsAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(string name)
        {
            var result = await _catalogMaterialService.AddAsync(name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, string name)
        {
            var result = await _catalogMaterialService.UpdateAsync(id, name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogMaterialDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _catalogMaterialService.RemoveAsync(id);
            return Ok(result);
        }

    }
}

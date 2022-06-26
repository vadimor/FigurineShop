using Catalog.Models.Response;
using Catalog.Services.Interfaces;
using Catalog.Configurations;
using Catalog.Models.Dtos;
using Catalog.Models.Requests;

namespace Catalog.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogSourceController : Controller
    {
        private ILogger<CatalogBffController> _logger;
        private IOptions<CatalogConfig> _config;
        private ICatalogSourceService _catalogSourceService;

        public CatalogSourceController(
        ILogger<CatalogBffController> logger,
        IOptions<CatalogConfig> config,
        ICatalogSourceService catalogSourceService)
        {
            _logger = logger;
            _config = config;
            _catalogSourceService = catalogSourceService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemsListResponse<CatalogSourceDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Sources()
        {
            var result = await _catalogSourceService.GetSourcesAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(string name)
        {
            var result = await _catalogSourceService.AddAsync(name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, string name)
        {
            var result = await _catalogSourceService.UpdateAsync(id, name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _catalogSourceService.RemoveAsync(id);
            return Ok(result);
        }

    }
}
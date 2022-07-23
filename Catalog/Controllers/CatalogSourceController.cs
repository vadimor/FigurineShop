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
        [ProducesResponseType(typeof(IEnumerable<CatalogSourceDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Sources()
        {
            var result = await _catalogSourceService.GetSourcesAsync();
            return Ok(result);
        }

        [HttpPost]

        // [AllowAnonymous]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSource(GetRequest request)
        {
            var result = await _catalogSourceService.GetSourceAsync(request.Id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(AddRequest request)
        {
            var result = await _catalogSourceService.AddAsync(request.Name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateRequest request)
        {
            var result = await _catalogSourceService.UpdateAsync(request.Id, request.Name);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogSourceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(RemoveRequest request)
        {
            var result = await _catalogSourceService.RemoveAsync(request.Id);
            return Ok(result);
        }
    }
}
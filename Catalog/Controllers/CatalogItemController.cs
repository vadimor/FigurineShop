using Catalog.Configurations;
using Catalog.Models.Dtos;
using Catalog.Models.Requests;
using Catalog.Models.Response;
using Catalog.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AdminPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogItemController : Controller
    {
        private ILogger<CatalogBffController> _logger;
        private IOptions<CatalogConfig> _config;
        private ICatalogItemService _catalogItemService;

        public CatalogItemController(
        ILogger<CatalogBffController> logger,
        IOptions<CatalogConfig> config,
        ICatalogItemService catalogItemService)
        {
            _logger = logger;
            _config = config;
            _catalogItemService = catalogItemService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items()
        {
            _logger.LogInformation("start Items");
            var result = await _catalogItemService.GetItemsAsync();
            _logger.LogInformation($"Items count: {result.Count()}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItem(GetRequest request)
        {
            var result = await _catalogItemService.GetItemAsync(request.Id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(AddItemRequest request)
        {
            var result = await _catalogItemService.AddAsync(request.Name, request.Price, request.Weight, request.Size, request.CatalogMaterialId, request.CatalogSourceId, request.PictureFileName, request.AvailableStock);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateItemRequest request)
        {
            var result = await _catalogItemService.UpdateAsync(request.Id, request.Name, request.Price, request.Weight, request.Size, request.CatalogMaterialId, request.CatalogSourceId, request.PictureFileName, request.AvailableStock);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(RemoveRequest request)
        {
            _logger.LogInformation($"Remove item id:{request.Id}");
            var result = await _catalogItemService.RemoveAsync(request.Id);
            return Ok(result);
        }
    }
}

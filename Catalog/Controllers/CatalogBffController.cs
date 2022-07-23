using Catalog.Configurations;
using Catalog.Models.Dtos;
using Catalog.Models.Enums;
using Catalog.Models.Requests;
using Catalog.Models.Response;
using Catalog.Services.Interfaces;

// using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Controllers;

// [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly ICatalogItemService _catalogItemService;
    private readonly IOptions<CatalogConfig> _config;
    private readonly ICatalogMaterialService _catalogMaterialService;
    private readonly ICatalogSourceService _catalogSourceService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        IOptions<CatalogConfig> config,
        ICatalogService catalogService,
        ICatalogItemService catalogItemService,
        ICatalogMaterialService catalogMaterialService,
        ICatalogSourceService catalogSourceService)
    {
        _logger = logger;
        _config = config;
        _catalogService = catalogService;
        _catalogItemService = catalogItemService;
        _catalogMaterialService = catalogMaterialService;
        _catalogSourceService = catalogSourceService;
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItem(GetRequest request)
    {
        var result = await _catalogItemService.GetItemAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter, CatalogTypeSorting> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters, request.Sorting);
        return Ok(result);
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogMaterialDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMaterials()
    {
        var list = await _catalogMaterialService.GetMaterialsAsync();
        var result = new ItemsListResponse<CatalogMaterialDto>
        {
            Data = list,
            Count = list.Count()
        };
        return Ok(result);
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogSourceDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSources()
    {
        var list = await _catalogSourceService.GetSourcesAsync();
        var result = new ItemsListResponse<CatalogSourceDto>
        {
            Data = list,
            Count = list.Count()
        };
        return Ok(result);
    }
}
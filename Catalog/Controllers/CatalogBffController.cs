using Catalog.Configurations;
using Catalog.Models.Dtos;
using Catalog.Models.Enums;
using Catalog.Models.Requests;
using Catalog.Models.Response;
using Catalog.Services.Interfaces;
// using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Controllers;

//[Authorize(Policy = AuthPolicy.AllowClientPolicy)]

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly IOptions<CatalogConfig> _config;
    private readonly ICatalogMaterialService _catalogMaterialService;
    private readonly ICatalogSourceService _catalogSourceService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        IOptions<CatalogConfig> config,
        ICatalogMaterialService catalogMaterialService,
        ICatalogSourceService catalogSourceService)
    {
        _logger = logger;
        _catalogService = catalogService;
        _config = config;
        _catalogMaterialService = catalogMaterialService;
        _catalogSourceService = catalogSourceService;
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
        return Ok(result);
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogMaterialDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMaterials()
    {
        var result = await _catalogMaterialService.GetMaterialsAsync();
        return Ok(result);
    }

    [HttpPost]

    // [AllowAnonymous]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogSourceDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSources()
    {
        var result = await _catalogSourceService.GetSourcesAsync();
        return Ok(result);
    }
}
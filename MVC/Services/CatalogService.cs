// using Infrastructure.Services.Interfaces;
using MVC.Dtos;
using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Catalog> GetCatalogItems(int page, int take, int? material, int? source, int? priceMin, int? priceMax, int? weightMin, int? weightMax, int? sizeMin, int? sizeMax)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (material.HasValue)
        {
            filters.Add(CatalogTypeFilter.Material, material.Value);
        }

        if (source.HasValue)
        {
            filters.Add(CatalogTypeFilter.Source, source.Value);
        }
        
        if (priceMin.HasValue)
        {
            filters.Add(CatalogTypeFilter.PriceMin, priceMin.Value);
        }

        if (priceMax.HasValue)
        {
            filters.Add(CatalogTypeFilter.PriceMax, priceMax.Value);
        }

        if (weightMin.HasValue)
        {
            filters.Add(CatalogTypeFilter.WeightMin, weightMin.Value);
        }

        if (weightMax.HasValue)
        {
            filters.Add(CatalogTypeFilter.WeightMax, weightMax.Value);
        }

        if (sizeMin.HasValue)
        {
            filters.Add(CatalogTypeFilter.SizeMin, sizeMin.Value);
        }
        
        if (sizeMax.HasValue)
        {
            filters.Add(CatalogTypeFilter.SizeMax, sizeMax.Value);
        }

        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/items",
           HttpMethod.Post,
           new PaginatedItemsRequest<CatalogTypeFilter>()
           {
               PageIndex = page,
               PageSize = take,
               Filters = filters
           });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetMaterials()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogMaterial>, object?>(
            $"{_settings.Value.CatalogUrl}/GetMaterials",
            HttpMethod.Post,
            null
            );

        var list = new List<SelectListItem>()
        {
            new SelectListItem { Text = "All" }
        };
        foreach (var item in result.Data)
        {
            if (item.Name.Count() > 20)
            {
                item.Name = $"{item.Name.Substring(0, 20)}...";
            }

            list.Add(new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

        return list;
    }

    public async Task<IEnumerable<SelectListItem>> GetSources()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogSource>, object?>(
            $"{_settings.Value.CatalogUrl}/GetSources",
            HttpMethod.Post,
            null
            );

        var list = new List<SelectListItem>()
        {
            new SelectListItem { Text = "All" }
        };

        foreach (var item in result.Data)
        {
            if (item.Name.Count() > 20)
            {
                item.Name = $"{item.Name.Substring(0, 20)}...";
            }

            list.Add(new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

        return list;
    }


    public async Task<CatalogItem> GetItem(int id)
    {
        var result = await _httpClient.SendAsync<CatalogItem, object?>(
            $"{_settings.Value.CatalogUrl}/GetItem",
            HttpMethod.Post,
            new GetItemRequest
            {
                Id = id
            }
            );

        return result;
    }
}

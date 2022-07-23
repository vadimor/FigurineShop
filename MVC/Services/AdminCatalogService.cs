using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
    public class AdminCatalogService : IAdminCatalogService
    {
        private readonly IHttpClientService _httpClient;
        private readonly AppSettings _settings;

        public AdminCatalogService(
            IHttpClientService httpClient,
            IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<IEnumerable<CatalogItem>> GetItems()
        {
            var result = await _httpClient.SendAsync<IEnumerable<CatalogItem>, object>(
                    $"{_settings.AdminItemUrl}/Items",
                    HttpMethod.Post,
                    null);

            return result;
        }

        public async Task<CatalogItem> GetItem(int id)
        {
            var result = await _httpClient.SendAsync<CatalogItem, object?>(
            $"{_settings.AdminItemUrl}/GetItem",
            HttpMethod.Post,
            new GetRequest
            {
                Id = id
            });

            return result;
        }

        public async Task<CatalogItem?> AddItem(AddItemRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogItem?, AddItemRequest>(
                    $"{_settings.AdminItemUrl}/Add",
                    HttpMethod.Post,
                    request);

            return result;
        }

        public async Task<CatalogItem?> UpdateItem(UpdateItemRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogItem?, UpdateItemRequest>(
                    $"{_settings.AdminItemUrl}/Update",
                    HttpMethod.Post,
                    request);

            return result;
        }

        public async Task<CatalogItem?> RemoveItem(RemoveRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogItem?, RemoveRequest>(
                    $"{_settings.AdminItemUrl}/Remove",
                    HttpMethod.Post,
                    request);
            return result;
        }

        public async Task<IEnumerable<SelectListItem>> GetMaterialSelectList()
        {
            var result = await _httpClient.SendAsync<IEnumerable<CatalogMaterial>, object?>(
            $"{_settings.AdminMaterialUrl}/Materials",
            HttpMethod.Post,
            null);

            var list = new List<SelectListItem>();

            foreach (var item in result)
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

        public async Task<IEnumerable<SelectListItem>> GetSourceSelectList()
        {
            var result = await _httpClient.SendAsync<IEnumerable<CatalogSource>, object?>(
            $"{_settings.AdminSourceUrl}/Sources",
            HttpMethod.Post,
            null);

            var list = new List<SelectListItem>();

            foreach (var item in result)
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

        public async Task<IEnumerable<CatalogMaterial>> GetMaterials()
        {
            var result = await _httpClient.SendAsync<IEnumerable<CatalogMaterial>, object>(
                    $"{_settings.AdminMaterialUrl}/Materials",
                    HttpMethod.Post,
                    null);

            return result;
        }

        public async Task<CatalogMaterial> GetMaterial(int id)
        {
            var result = await _httpClient.SendAsync<CatalogMaterial, object?>(
            $"{_settings.AdminMaterialUrl}/GetMaterial",
            HttpMethod.Post,
            new GetRequest
            {
                Id = id
            });

            return result;
        }

        public async Task<CatalogMaterial?> AddMaterial(AddRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogMaterial?, AddRequest>(
                    $"{_settings.AdminMaterialUrl}/Add",
                    HttpMethod.Post,
                    request);

            return result;
        }

        public async Task<CatalogMaterial?> UpdateMaterial(UpdateRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogMaterial?, UpdateRequest>(
                    $"{_settings.AdminMaterialUrl}/Update",
                    HttpMethod.Post,
                    request);

            return result;
        }

        public async Task<CatalogMaterial?> RemoveMaterial(RemoveRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogMaterial?, RemoveRequest>(
                    $"{_settings.AdminMaterialUrl}/Remove",
                    HttpMethod.Post,
                    request);
            return result;
        }

        public async Task<IEnumerable<CatalogSource>> GetSources()
        {
            var result = await _httpClient.SendAsync<IEnumerable<CatalogSource>, object>(
                    $"{_settings.AdminSourceUrl}/Sources",
                    HttpMethod.Post,
                    null);

            return result;
        }

        public async Task<CatalogSource> GetSource(int id)
        {
            var result = await _httpClient.SendAsync<CatalogSource, object?>(
            $"{_settings.AdminSourceUrl}/GetSource",
            HttpMethod.Post,
            new GetRequest
            {
                Id = id
            });

            return result;
        }

        public async Task<CatalogSource?> AddSource(AddRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogSource?, AddRequest>(
                    $"{_settings.AdminSourceUrl}/Add",
                    HttpMethod.Post,
                    request);

            return result;
        }

        public async Task<CatalogSource?> UpdateSource(UpdateRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogSource?, UpdateRequest>(
                    $"{_settings.AdminSourceUrl}/Update",
                    HttpMethod.Post,
                    request);

            return result;
        }

        public async Task<CatalogSource?> RemoveSource(RemoveRequest request)
        {
            var result = await _httpClient.SendAsync<CatalogSource?, RemoveRequest>(
                    $"{_settings.AdminSourceUrl}/Remove",
                    HttpMethod.Post,
                    request);
            return result;
        }
    }
}

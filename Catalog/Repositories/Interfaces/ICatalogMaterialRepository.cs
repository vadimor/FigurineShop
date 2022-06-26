using Catalog.Data;
using Catalog.Data.Entities;

namespace Catalog.Repositories.Interfaces
{
    public interface ICatalogMaterialRepository
    {
        Task<ItemsList<CatalogMaterial>> GetMaterialsAsync();
        Task<CatalogMaterial> AddAsync(string name);
        Task<CatalogMaterial?> RemoveAsync(int id);
        Task<CatalogMaterial?> UpdateAsync(int id, string name);
    }
}

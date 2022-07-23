using Catalog.Data;
using Catalog.Data.Entities;

namespace Catalog.Repositories.Interfaces
{
    public interface ICatalogMaterialRepository
    {
        Task<IEnumerable<CatalogMaterial>> GetMaterialsAsync();
        Task<CatalogMaterial?> GetMaterial(int id);
        Task<CatalogMaterial> AddAsync(string name);
        Task<CatalogMaterial?> RemoveAsync(int id);
        Task<CatalogMaterial?> UpdateAsync(int id, string name);
    }
}

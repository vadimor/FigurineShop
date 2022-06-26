using Catalog.Data;
using Catalog.Data.Entities;

namespace Catalog.Repositories.Interfaces
{
    public interface ICatalogSourceRepository
    {
        Task<ItemsList<CatalogSource>> GetSourcesAsync();
        Task<CatalogSource> AddAsync(string name);
        Task<CatalogSource?> RemoveAsync(int id);
        Task<CatalogSource?> UpdateAsync(int id, string name);
    }
}

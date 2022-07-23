using Catalog.Data;
using Catalog.Data.Entities;

namespace Catalog.Repositories.Interfaces
{
    public interface ICatalogSourceRepository
    {
        Task<IEnumerable<CatalogSource>> GetSourcesAsync();
        Task<CatalogSource?> GetSource(int id);
        Task<CatalogSource> AddAsync(string name);
        Task<CatalogSource?> RemoveAsync(int id);
        Task<CatalogSource?> UpdateAsync(int id, string name);
    }
}

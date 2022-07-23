using Catalog.Data;
using Catalog.Data.Entities;
using Catalog.Repositories.Interfaces;

namespace Catalog.Repositories
{
    public class CatalogSourceRepository : ICatalogSourceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogSourceRepository> _logger;

        public CatalogSourceRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogSourceRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<CatalogSource> AddAsync(string name)
        {
            var source = new CatalogSource { Name = name };

            await _dbContext.CatalogSources.AddAsync(source);

            _dbContext.SaveChanges();

            return source;
        }

        public async Task<IEnumerable<CatalogSource>> GetSourcesAsync()
        {
            var sources = await _dbContext.CatalogSources
                .ToListAsync();

            return sources;
        }

        public async Task<CatalogSource?> GetSource(int id)
        {
            var result = await _dbContext.CatalogSources
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<CatalogSource?> RemoveAsync(int id)
        {
            var source = await _dbContext.CatalogSources.FirstOrDefaultAsync(x => x.Id == id);

            if (source is null)
            {
                return null;
            }

            _dbContext.Remove(source);
            _dbContext.SaveChanges();

            return source;
        }

        public async Task<CatalogSource?> UpdateAsync(int id, string name)
        {
            var source = await _dbContext.CatalogSources.FirstOrDefaultAsync(x => x.Id == id);

            if (source is null)
            {
                return null;
            }

            source.Name = name;
            _dbContext.CatalogSources.Update(source);
            _dbContext.SaveChanges();

            return source;
        }
    }
}

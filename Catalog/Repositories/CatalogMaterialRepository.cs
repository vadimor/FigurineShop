using Catalog.Data;
using Catalog.Data.Entities;
using Catalog.Repositories.Interfaces;

namespace Catalog.Repositories
{
    public class CatalogMaterialRepository : ICatalogMaterialRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogMaterialRepository> _logger;

        public CatalogMaterialRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogMaterialRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<CatalogMaterial> AddAsync(string name)
        {
            var material = new CatalogMaterial { Name = name };

            await _dbContext.CatalogMaterials.AddAsync(material);

            _dbContext.SaveChanges();

            return material;
        }

        public async Task<IEnumerable<CatalogMaterial>> GetMaterialsAsync()
        {
            var materials = await _dbContext.CatalogMaterials
                .ToListAsync();

            return materials;
        }

        public async Task<CatalogMaterial?> GetMaterial(int id)
        {
            var result = await _dbContext.CatalogMaterials
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<CatalogMaterial?> RemoveAsync(int id)
        {
            var material = await _dbContext.CatalogMaterials.FirstOrDefaultAsync(x => x.Id == id);

            if (material is null)
            {
                return null;
            }

            _dbContext.Remove(material);
            _dbContext.SaveChanges();

            return material;
        }

        public async Task<CatalogMaterial?> UpdateAsync(int id, string name)
        {
            var material = await _dbContext.CatalogMaterials.FirstOrDefaultAsync(x => x.Id == id);

            if (material is null)
            {
                return null;
            }

            material.Name = name;
            _dbContext.CatalogMaterials.Update(material);
            _dbContext.SaveChanges();

            return material;
        }
    }
}

using System.Linq;
using Catalog.Data;
using Catalog.Data.Entities;
using Catalog.Data.Enums;
using Catalog.Repositories.Interfaces;

namespace Catalog.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogItemRepository> _logger;

        public CatalogItemRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogItemRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(
             int pageIndex,
             int pageSize,
             int? materialFilter,
             int? sourceFilter,
             decimal? priceMin,
             decimal? priceMax,
             int? weightMin,
             int? weightMax,
             double? sizeMin,
             double? sizeMax,
             CatalogTypeSorting? sorting)
        {
            IQueryable<CatalogItem> query = _dbContext.CatalogItems;

            if (materialFilter.HasValue)
            {
                query = query.Where(w => w.CatalogMaterialId == materialFilter.Value);
            }

            if (sourceFilter.HasValue)
            {
                query = query.Where(w => w.CatalogSourceId == sourceFilter.Value);
            }

            if (priceMin >= 0 && priceMax > priceMin)
            {
                query = query.Where(w => priceMin <= w.Price && w.Price <= priceMax);
            }

            if (weightMin >= 0 && weightMax > weightMin)
            {
                query = query.Where(w => weightMin <= w.Weight && w.Weight <= weightMax);
            }

            if (sizeMin >= 0 && sizeMax > sizeMin)
            {
                query = query.Where(w => sizeMin <= w.Size && w.Size <= sizeMax);
            }

            switch (sorting)
            {
                case CatalogTypeSorting.PriceAsc:
                    query = query.OrderBy(x => x.Price);
                    break;
                case CatalogTypeSorting.PriceDesc:
                    query = query.OrderByDescending(x => x.Price);
                    break;
                case CatalogTypeSorting.WeighAsc:
                    query = query.OrderBy(x => x.Weight);
                    break;
                case CatalogTypeSorting.WeighDesc:
                    query = query.OrderByDescending(x => x.Weight);
                    break;
                case CatalogTypeSorting.SizeAsc:
                    query = query.OrderBy(x => x.Size);
                    break;
                case CatalogTypeSorting.SizeDesc:
                    query = query.OrderByDescending(x => x.Size);
                    break;
                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }

            var totalItems = await query.LongCountAsync();

            var itemsOnPage = await query.Include(i => i.Material)
               .Include(i => i.Source)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();

            return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<CatalogItem?> GetItem(int id)
        {
            var result = await _dbContext.CatalogItems
                .Include(x => x.Material)
                .Include(x => x.Source)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsAsync()
        {
            var items = await _dbContext.CatalogItems
                .Include(i => i.Material)
                .Include(i => i.Source)
                .ToListAsync();

            return items;
        }

        public async Task<CatalogItem?> RemoveAsync(int id)
        {
            var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
            {
                return null;
            }

            var result = _dbContext.Remove(item);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public async Task<CatalogItem?> UpdateAsync(int id, string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock)
        {
            var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
            {
                return null;
            }

            item.Name = name;
            item.Price = price;
            item.Weight = weight;
            item.Size = size;
            item.CatalogMaterialId = catalogMaterialId;
            item.CatalogSourceId = catalogSourceId;
            item.PictureFileName = pictureFileName;
            item.AvailableStock = availableStock;

            var result = _dbContext.CatalogItems.Update(item);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public async Task<CatalogItem> AddAsync(string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock)
        {
            var item = new CatalogItem
            {
                Name = name,
                Price = price,
                Weight = weight,
                Size = size,
                CatalogMaterialId = catalogMaterialId,
                CatalogSourceId = catalogSourceId,
                PictureFileName = pictureFileName,
                AvailableStock = availableStock
            };

            var result = await _dbContext.CatalogItems.AddAsync(item);
            _dbContext.SaveChanges();

            return result.Entity;
        }
    }
}

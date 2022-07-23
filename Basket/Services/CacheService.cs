using Basket.Configuration;
using Basket.Services.Interfaces;
using StackExchange.Redis;

namespace Basket.Services
{
    public class CacheService : ICacheService
    {
        private readonly ILogger<CacheService> _logger;
        private readonly ICacheConnectionService _cacheConnectionService;
        private readonly RedisConfig _config;
        private readonly IJsonSerializer _jsonSerializer;

        public CacheService(
            ILogger<CacheService> logger,
            ICacheConnectionService cacheConnectionService,
            IOptions<RedisConfig> config,
            IJsonSerializer jsonSerializer)
        {
            _logger = logger;
            _cacheConnectionService = cacheConnectionService;
            _config = config.Value;
            _jsonSerializer = jsonSerializer;
        }

        public async Task AddOrUpdateAsync<T>(string key, T? value)
        {
            var redis = GetRedisDatabase();
            var expiry = _config.CacheTimeout;
            string? serialized;
            if (value is not null)
            {
                serialized = _jsonSerializer.Serialize<T>(value);
            }
            else
            {
                serialized = null;
            }

            if (await redis.StringSetAsync(key, serialized, expiry))
            {
                _logger.LogInformation($"Cached value for key {key} cached");
            }
            else
            {
                _logger.LogInformation($"Cached value for key {key} updated");
            }
        }

        public async Task RemoveAsync(string key)
        {
            var redis = GetRedisDatabase();

            await redis.KeyDeleteAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var redis = GetRedisDatabase();

            var serialized = await redis.StringGetAsync(key);
            return serialized.HasValue ?
                _jsonSerializer.Deserialize<T>(serialized.ToString())
                : default(T) !;
        }

        private IDatabase GetRedisDatabase() => _cacheConnectionService.Connection.GetDatabase();
    }
}

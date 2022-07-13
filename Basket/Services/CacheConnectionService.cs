using Basket.Configuration;
using Basket.Services.Interfaces;
using StackExchange.Redis;

namespace Basket.Services
{
    public class CacheConnectionService : ICacheConnectionService, IDisposable
    {
        private readonly Lazy<ConnectionMultiplexer> _connectionLazy;
        private bool _disposed;

        public CacheConnectionService(IOptions<RedisConfig> config)
        {
            var redisConfigOptions = ConfigurationOptions.Parse(config.Value.Host);
            redisConfigOptions.AsyncTimeout = 180000;
            redisConfigOptions.ConnectTimeout = 180000;
            redisConfigOptions.SyncTimeout = 180000;
            redisConfigOptions.AbortOnConnectFail = false;
            _connectionLazy = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(redisConfigOptions));
        }

        public IConnectionMultiplexer Connection => _connectionLazy.Value;
        public void Dispose()
        {
            if (!_disposed)
            {
                Connection.Dispose();
                _disposed = true;
            }
        }
    }
}

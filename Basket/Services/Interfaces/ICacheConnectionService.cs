using StackExchange.Redis;

namespace Basket.Services.Interfaces
{
    public interface ICacheConnectionService
    {
        public IConnectionMultiplexer Connection { get; }
    }
}

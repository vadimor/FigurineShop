﻿namespace Basket.Services.Interfaces
{
    public interface ICacheService
    {
        Task AddOrUpdateAsync<T>(string key, T? value);
        Task<T> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }
}
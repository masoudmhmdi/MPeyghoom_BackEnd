using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using MPeyghoom.Configuration.MemoryCash;

namespace MPeyghoom.Services.CashService;

public class CashService : ICashService
{
    private readonly  MyMemoryCache _memoryCache;

    public CashService(MyMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }


    public bool SetValue(string key, object value)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSize(1)
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(120));

            _memoryCache.Cache.Set(key, value, cacheEntryOptions);
            return true;
        
    }

    public T? GetValue<T>(string key)
    {
        _memoryCache.Cache.TryGetValue(key, out T? cacheValue);
        return cacheValue;

    }

}
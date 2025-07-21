using Microsoft.Extensions.Caching.Memory;

namespace MPeyghoom.Configuration.MemoryCash;

public class MyMemoryCache
{
    public MemoryCache Cache { get; } = new MemoryCache(
        new MemoryCacheOptions
        {
            SizeLimit = 1024,
        });
}

using Microsoft.Extensions.Caching.Memory;

namespace MPeyghoom.Services.CashService;

public interface ICashService
{
    
    public bool SetValue(string key, object value);
    public T? GetValue<T>(string key);
    
}
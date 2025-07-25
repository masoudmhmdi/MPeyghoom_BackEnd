using MongoDB.Driver;
using MPeyghoom.Configuration.MemoryCash;
using MPeyghoom.Models;
using MPeyghoom.Services.AuthService;
using MPeyghoom.Services.CashService;

public class AuthService : IAuthService
{
    private readonly  ICashService _cashService;
    private readonly IMongoCollection<User> _booksCollection;
    
    public AuthService(ICashService cashService)
    {
        this._cashService = cashService;
    }

    public int GetVerificationCode(int phoneNumber)
    {
        _cashService.SetValue("VerificationCode", phoneNumber);

        var num = _cashService.GetValue<int>("VerificationCode");
        
        return num;
    }

    public void RegisterUser(int phoneNumber, string name)
    {
        throw new NotImplementedException();
    }
}
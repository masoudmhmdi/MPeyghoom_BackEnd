using MPeyghoom.Configuration.MemoryCash;
using MPeyghoom.Services.AuthService;
using MPeyghoom.Services.CashService;

public class AuthService : IAuthService
{
    private readonly  ICashService _cashService;
    
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
}
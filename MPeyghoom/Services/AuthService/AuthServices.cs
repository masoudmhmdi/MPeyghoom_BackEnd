using MPeyghoom.Configuration.Result;
using MPeyghoom.Repositories;
using MPeyghoom.Services.CashService;

namespace MPeyghoom.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly  ICashService _cashService;
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    
    public AuthService(
        ICashService cashService,
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        this._cashService = cashService;
        this._userRepository = userRepository;
        _jwtService = jwtService;
    }

    public Result<int> GenerateVerificationCode(int phoneNumber)
    {
        var random = new Random();
        var randomNumber = random.Next(100000, 1000000);
        
        _cashService.SetValue(phoneNumber.ToString(), randomNumber);
        
        return Result.Success(randomNumber);
    }

    public Result<string> GetTokenForValidatePhoneNumber(long phoneNumber)
    {
         var token = _jwtService.GenerateTokenForValidatePhoneNumber();
         return Result.Success(token);
    }

    public bool VerifyPhoneNumber(int phoneNumber, int verificationCode)
    {
        
        var code = _cashService.GetValue<int>(phoneNumber.ToString());

        if (code == 0)
        {
            return false;
        }

        if (code == verificationCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RegisterUser(int phoneNumber, string name)
    {
        throw new NotImplementedException();
    }
}
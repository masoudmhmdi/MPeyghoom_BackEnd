using MPeyghoom.Configuration.Result;

namespace MPeyghoom.Services.AuthService;

public interface IAuthService
{
    public Result<int> GenerateVerificationCode(int phoneNumber);
    public Result<string> GetTokenForValidatePhoneNumber(long phoneNumber);
    public void RegisterUser(int phoneNumber, string name);

}
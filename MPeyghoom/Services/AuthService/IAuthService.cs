namespace MPeyghoom.Services.AuthService;

public interface IAuthService
{
    public Task<int> GetVerificationCode(int phoneNumber);
    public void RegisterUser(int phoneNumber, string name);

}
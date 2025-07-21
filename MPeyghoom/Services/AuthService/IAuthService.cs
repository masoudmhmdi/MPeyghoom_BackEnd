namespace MPeyghoom.Services.AuthService;

public interface IAuthService
{
    public int GetVerificationCode(int phoneNumber);
    
}
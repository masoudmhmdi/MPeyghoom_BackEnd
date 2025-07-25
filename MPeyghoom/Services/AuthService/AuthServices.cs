using MongoDB.Driver;
using MPeyghoom.Configuration.MemoryCash;
using MPeyghoom.Models;
using MPeyghoom.Repositories;
using MPeyghoom.Services.AuthService;
using MPeyghoom.Services.CashService;

public class AuthService : IAuthService
{
    private readonly  ICashService _cashService;
    private readonly IUserRepository _userRepository;
    
    public AuthService(ICashService cashService, IUserRepository userRepository)
    {
        this._cashService = cashService;
        this._userRepository = userRepository;
    }

    public async Task<int> GetVerificationCode(int phoneNumber)
    {
        _cashService.SetValue("VerificationCode", phoneNumber);

        var num = _cashService.GetValue<int>("VerificationCode");

        var x = await _userRepository.GetUserByPhoneNumber(093333);
        return num;
    }

    public void RegisterUser(int phoneNumber, string name)
    {
        throw new NotImplementedException();
    }
}
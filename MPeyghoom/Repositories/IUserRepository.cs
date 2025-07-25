using MPeyghoom.Models;

namespace MPeyghoom.Repositories;

public interface IUserRepository : IDisposable
{
    Task<List<User>> GetUserByPhoneNumber(int phoneNumber);
}
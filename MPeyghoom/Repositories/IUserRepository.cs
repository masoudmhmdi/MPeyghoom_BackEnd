using MPeyghoom.Models;

namespace MPeyghoom.Repositories;

public interface IUserRepository 
{
    Task<User> GetUserByPhoneNumberAsync(int phoneNumber);
    Task CreateNewUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}
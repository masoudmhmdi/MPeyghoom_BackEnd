using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MPeyghoom.Models;
using MPeyghoom.Options;

namespace MPeyghoom.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(IOptionsSnapshot<PeyghoomMongoDbSetting> bookStoreDatabaseSettings){
        
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _userCollection = mongoDatabase.GetCollection<User>(
            bookStoreDatabaseSettings.Value.UsersCollectionName);

    }

    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    public async Task<User> GetUserByPhoneNumberAsync(int phoneNumber)
    {
        var user = await _userCollection
            .Find(u => u.PhoneNumber == phoneNumber)
            .FirstOrDefaultAsync();
        return user;

    }

    public async Task CreateNewUserAsync(User user)
    {
        await _userCollection.InsertOneAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
    }

    public async Task DeleteUserAsync(User user)
    {
        await _userCollection.DeleteOneAsync(x => x.Id == user.Id);
    }
}
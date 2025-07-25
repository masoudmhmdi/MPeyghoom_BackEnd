using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MPeyghoom.Models;
using MPeyghoom.Options;

namespace MPeyghoom.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoDatabase _peyghoomDatabase;
    private readonly IOptionsSnapshot<PeyghoomMongoDbSetting> _peyghoomMongoDbSetting;
    private readonly IMongoCollection<User> _booksCollection;

    public UserRepository(
        IOptionsSnapshot<PeyghoomMongoDbSetting> bookStoreDatabaseSettings){
        
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<User>(
            bookStoreDatabaseSettings.Value.UsersCollectionName);
        var u = _booksCollection.Find(_ => true).ToList();

    }

    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
//        GC.SuppressFinalize(this);
    }

    public async Task<List<User>> GetUserByPhoneNumber(int phoneNumber)
    {
           var users =  await _booksCollection.Find(_ => true).ToListAsync();
        
        var uu =  new User()
        {
            Id = "as;dafksd",
            PhoneNumber = 131234
        };


        return users;

    }


    ~UserRepository()
    {
        ReleaseUnmanagedResources();
    }
}
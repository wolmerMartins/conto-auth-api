using ContoAuthApi.Accounts.Entities;
using ContoAuthApi.Accounts.Repositories.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ContoAuthApi.Accounts.Repositories;

public class AccountsRepository : IAccountsRepository
{
    private readonly IMongoCollection<Account> _collection;

    public AccountsRepository(IOptions<AccountsDatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        _collection = database.GetCollection<Account>(databaseSettings.Value.CollectionName);
    }

    public Task<Account> GetAccount(string email)
        => _collection.Find(account => account.Email == email).FirstOrDefaultAsync();
}

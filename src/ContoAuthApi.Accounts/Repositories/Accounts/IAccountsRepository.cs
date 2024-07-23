using ContoAuthApi.Accounts.Entities;

namespace ContoAuthApi.Accounts.Repositories;

public interface IAccountsRepository
{
    Task<Account> GetAccount(string email);
}

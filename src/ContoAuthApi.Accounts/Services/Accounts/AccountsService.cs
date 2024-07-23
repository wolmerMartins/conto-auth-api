using ContoAuthApi.Accounts.Repositories;

namespace ContoAuthApi.Accounts.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountRepository;

    public AccountsService(IAccountsRepository accountsRepository)
    {
        _accountRepository = accountsRepository;
    }

    public async Task<bool> AccountExists(string email)
    {
        var account = await _accountRepository.GetAccount(email);

        return account != null;
    }
}

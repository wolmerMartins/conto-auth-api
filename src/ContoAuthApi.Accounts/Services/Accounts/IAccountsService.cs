namespace ContoAuthApi.Accounts.Services;

public interface IAccountsService
{
    Task<bool> AccountExists(string email);
}

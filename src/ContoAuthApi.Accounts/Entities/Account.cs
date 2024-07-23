namespace ContoAuthApi.Accounts.Entities;

public class Account
{
    private string _email;
    public string Email
    {
        get { return _email; }
    }

    public Account(string email)
    {
        _email = email;
    }
}

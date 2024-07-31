using ContoAuthApi.Accounts.Entities;
using ContoAuthApi.Accounts.Repositories;
using ContoAuthApi.Accounts.Services;
using Moq;

namespace ContoAuthApi.Accounts.Tests;

public class AccountsServiceTest
{
    private readonly Mock<IAccountsRepository> _repository;

    private readonly IAccountsService _service;

    public AccountsServiceTest()
    {
        _repository = new Mock<IAccountsRepository>();

        _service = new AccountsService(_repository.Object);
    }

    [Fact(DisplayName = "Try to retrieve the account from DB")]
    public async Task Test_1()
    {
        await _service.AccountExists("test@email.com");

        _repository.Verify(r => r.GetAccount(It.IsAny<string>()), Times.Once);
    }

    [Fact(DisplayName = "Returns false when the account for the given email doesn't exist")]
    public async Task Test_2()
    {
        var result = await _service.AccountExists("test@email.com");

        Assert.False(result);
    }

    [Fact(DisplayName = "Returns true when the account for the given email exists")]
    public async Task Test_3()
    {
        var email = "test@email.com";

        _repository
            .Setup(r => r.GetAccount(It.IsAny<string>()))
            .ReturnsAsync(new Account(email));

        var result = await _service.AccountExists(email);

        Assert.True(result);
    }
}

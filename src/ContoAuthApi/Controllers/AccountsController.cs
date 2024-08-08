using ContoAuthApi.Accounts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContoAuthApi.Controllers;

[Route("accounts")]
public class AccountsController : Controller
{
    private readonly IAccountsService _accountsService;

    public AccountsController(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    [HttpGet("{email}/exists")]
    public async Task<IActionResult> AccountExists(string email)
    {
        var result = await _accountsService.AccountExists(email);

        return Ok(new
        {
            exists = result
        });
    }
}

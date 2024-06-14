using IncidentReport.Interfaces;
using IncidentReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncidentReport.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        [Route("api/account/create")]
        public async Task<IActionResult> AddAccount([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Account is null");
            }

            try
            {
                await _accountRepository.AddAccount(account);
                return Ok(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while adding the account");
            }
        }

        [HttpGet]
        [Route("api/account/get-all")]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountRepository.GetAccountsAsync();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving the accounts");
            }
        }

        [HttpDelete]
        [Route("api/account/delete-{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountRepository.DeleteAccount(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while deleting the account");
            }
        }
    }
}

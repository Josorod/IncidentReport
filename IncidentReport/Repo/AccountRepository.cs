using IncidentReport.Data;
using IncidentReport.Interfaces;
using IncidentReport.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Repo
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext dc;

        public AccountRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task AddAccount(Account account)
        {
           await dc.Accounts.AddAsync(account);
        }

        public async Task DeleteAccount(int Id)
        {
            var account = await dc.Accounts.FindAsync(Id);
            if (account != null)
            {
                dc.Accounts.Remove(account);
            }
        }

        public async Task<Account> FindAccount(int id)
        {
            return await dc.Accounts.FindAsync(id);
        }
        public async Task<Account> GetAccountByNameAsync(string name)
        {
            return await dc.Accounts.Include(a => a.Contact)
                                          .FirstOrDefaultAsync(a => a.Name == name);
        }


        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await dc.Accounts.ToListAsync();
        }
    }
}

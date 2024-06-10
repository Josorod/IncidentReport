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
        public void AddAccount(Account account)
        {
            dc.Accounts.Add(account);
        }

        public void DeleteAccount(int Id)
        {
            var account = dc.Accounts.Find(Id);
            dc.Accounts.Remove(account);
        }

        public async Task<Account> FindAccount(int id)
        {
            return await dc.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await dc.Accounts.ToListAsync();
        }
    }
}

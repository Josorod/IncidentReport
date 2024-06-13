using IncidentReport.Models;


namespace IncidentReport.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByNameAsync(string accountName);
        void AddAccount(Account account);
        void DeleteAccount(int Id);
        Task<Account> FindAccount(int id);
    }
}

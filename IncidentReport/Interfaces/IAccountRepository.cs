using IncidentReport.Models;


namespace IncidentReport.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        void AddAccount(Account account);
        void DeleteAccount(int Id);
        Task<Account> FindAccount(int id);
    }
}

﻿using IncidentReport.Models;


namespace IncidentReport.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByNameAsync(string accountName);
        Task AddAccount(Account account);
        Task DeleteAccount(int Id);
        Task<Account> FindAccount(int id);
    }
}

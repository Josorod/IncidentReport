using IncidentReport.Models;

namespace IncidentReport.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContactByAccountNameAsync(string accountName);
        Task AddContact(Contact contact);
        Task DeleteContact(int Id);
        Task<Contact> FindContact(int id);
    }
}

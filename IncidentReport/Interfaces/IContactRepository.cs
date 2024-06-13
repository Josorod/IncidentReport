using IncidentReport.Models;

namespace IncidentReport.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContactByEmailAsync(string email);
        void AddContact(Contact contact);
        void DeleteContact(int Id);
        Task<Contact> FindContact(int id);
    }
}

using IncidentReport.Models;

namespace IncidentReport.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        void AddContact(Contact contact);
        void DeleteContact(int Id);
        Task<Contact> FindContact(int id);
    }
}

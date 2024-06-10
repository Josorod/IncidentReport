using IncidentReport.Data;
using IncidentReport.Interfaces;
using IncidentReport.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Repo
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext dc;

        public ContactRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddContact(Contact contact)
        {
            dc.Contacts.Add(contact);
        }

        public void DeleteContact(int Id)
        {
            var contact = dc.Contacts.Find(Id);
            dc.Contacts.Remove(contact);
        }

        public async Task<Contact> FindContact(int id)
        {
            return await dc.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await dc.Contacts.ToListAsync();
        }
    }
}

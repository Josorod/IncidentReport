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
        public async Task AddContact(Contact contact)
        {
            await dc.Contacts.AddAsync(contact);
        }

        public async Task DeleteContact(int Id)
        {
            var contact = await dc.Contacts.FindAsync(Id);
            if (contact != null)
            {
                dc.Contacts.Remove(contact);
            }
        }

        public async Task<Contact> FindContact(int id)
        {
            return await dc.Contacts.FindAsync(id);
        }
        public async Task<Contact> GetContactByAccountNameAsync(string accountName)
        {
            var account = await dc.Accounts
                                        .Include(a => a.Contact) // Ensure Contact is included
                                        .FirstOrDefaultAsync(a => a.Name == accountName);

            return account?.Contact;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await dc.Contacts.ToListAsync();
        }
    }
}

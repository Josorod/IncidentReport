using IncidentReport.Data;
using IncidentReport.Interfaces;

namespace IncidentReport.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IAccountRepository AccountRepository => new AccountRepository(dc);

        public IContactRepository ContactRepository => new ContactRepository(dc);

        public IIncidentRepository IncidentRepository => new IncidentRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}

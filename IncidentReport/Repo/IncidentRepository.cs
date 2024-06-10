using IncidentReport.Data;
using IncidentReport.Interfaces;
using IncidentReport.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Repo
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly DataContext dc;

        public IncidentRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddIncident(Incident incident)
        {
            dc.Incidents.Add(incident);
        }

        public void DeleteIncident(int Id)
        {
            var incident = dc.Incidents.Find(Id);
            dc.Incidents.Remove(incident);
        }

        public async Task<Incident> FindIncident(int id)
        {
            return await dc.Incidents.FindAsync(id);
        }

        public async Task<IEnumerable<Incident>> GetIncidentsAsync()
        {
            return await dc.Incidents.ToListAsync();
        }
    }
}

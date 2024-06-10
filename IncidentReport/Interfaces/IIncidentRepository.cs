using IncidentReport.Models;

namespace IncidentReport.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<Incident>> GetIncidentsAsync();
        void AddIncident(Incident incident);
        void DeleteIncident(int Id);
        Task<Incident> FindIncident(int id);
    }
}

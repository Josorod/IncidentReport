namespace IncidentReport.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}

namespace IncidentReport.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}

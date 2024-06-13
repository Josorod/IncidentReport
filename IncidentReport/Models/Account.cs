using System.Text.Json.Serialization;

namespace IncidentReport.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } // Unique string field

        public int ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }

        [JsonIgnore]
        public ICollection<Incident> Incidents { get; set; }
    }
}

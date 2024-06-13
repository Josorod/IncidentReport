using System.Text.Json.Serialization;

namespace IncidentReport.Models
{
    public class Incident
    {
        public int Id { get; set; } // Primary key
        public string Description { get; set; }

        public int AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace IncidentReport.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // Unique identifier

        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }

}

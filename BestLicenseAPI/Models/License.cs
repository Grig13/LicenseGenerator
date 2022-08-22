using System.Text.Json.Serialization;

namespace BestLicenseAPI.Models
{
    public class License
    {

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string LicenseType { get; set; } = string.Empty;
        public string LicenseContent { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}

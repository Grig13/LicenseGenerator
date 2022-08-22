namespace BestLicenseAPI.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<License> Licenses { get; set; }
        public List<Product> Products { get; set; }
    }
}

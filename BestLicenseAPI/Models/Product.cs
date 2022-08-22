namespace BestLicenseAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string KeyPair { get; set; } = string.Empty;
        
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

        public License License { get; set; }
    }
}

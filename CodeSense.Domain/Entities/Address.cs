using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities
{
    public class Address : EntityBase
    {
        public int ClientCompanyId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }

        // navigational properties
        public Company ClientCompany { get; set; }
    }
}
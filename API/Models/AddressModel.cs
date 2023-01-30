using System.ComponentModel.DataAnnotations;

namespace PROJ.API.Models
{
    public class AddressModel
    {
        public AddressModel(int id, string addressLine, string country, string city)
        {
            Id = id;
            AddressLine = addressLine;
            Country = country;
            City = city;
        }

        public int Id { get; set; }

        [Required]
        public string AddressLine { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace PROJ.API.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required]
        public string Development { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int AddressId { get; set; }

        public EmployeeModel(int id, string fullName, string development, string email)
        {
            Id = id;
            FullName = fullName;
            Development = development;
            Email = email;
        }

        public EmployeeModel(int id, string fullName, string development, string email, int addressId)
        {
            Id = id;
            FullName = fullName;
            Development = development;
            Email = email;
            AddressId = addressId;
        }

        public EmployeeModel()
        {
        }
    }
}

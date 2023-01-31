using System.ComponentModel.DataAnnotations;

namespace PROJ.API.Models

{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Shopping_App.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Select Role")]
        public string Role { get; set; }
    }
}

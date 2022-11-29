using System.ComponentModel.DataAnnotations;

namespace Shopping_App.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        //public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please select Role")]
        public string Role { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

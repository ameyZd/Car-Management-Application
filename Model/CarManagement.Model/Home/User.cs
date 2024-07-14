using System.ComponentModel.DataAnnotations;

namespace CarManagement.Model.Home
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is mandatory")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }

    }
}

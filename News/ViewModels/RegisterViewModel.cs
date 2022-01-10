using System.ComponentModel.DataAnnotations;

namespace News.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [Compare("Password", ErrorMessage = "PasswordConfimRequired")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}

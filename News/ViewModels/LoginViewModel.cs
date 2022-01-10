using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace News.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

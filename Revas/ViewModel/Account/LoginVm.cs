using System.ComponentModel.DataAnnotations;

namespace Revas.ViewModel.Account
{
    public class LoginVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordofEmail { get; set; }
        [Required]
        public bool RemembeMe { get; set; }
    }
}

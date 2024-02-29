using System.ComponentModel.DataAnnotations;

namespace SignalR.WebUI.Dtos.IdentityDtos
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifreler birbiri ile uyumlu değil.")]
        public string ConfirmPassword { get; set; }
    }
}

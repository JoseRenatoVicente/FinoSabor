using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Infra.CrossCutting.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Usernameoremail { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SistemaERP.Infra.CrossCutting.Identity.ViewModels
{
    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Newpassword { get; set; }
    }
}

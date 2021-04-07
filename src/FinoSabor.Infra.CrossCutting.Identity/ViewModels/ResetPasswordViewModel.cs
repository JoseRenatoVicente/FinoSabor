using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Infra.CrossCutting.Identity.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Token { get; set; }
    }
}

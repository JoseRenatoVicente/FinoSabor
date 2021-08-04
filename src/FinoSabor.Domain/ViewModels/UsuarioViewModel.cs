using System;

namespace FinoSabor.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; }
        public DateTime data_cadastro { get; set; }
        public string Email { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}

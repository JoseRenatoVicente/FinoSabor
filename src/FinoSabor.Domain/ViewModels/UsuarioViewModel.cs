using System;

namespace FinoSabor.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}

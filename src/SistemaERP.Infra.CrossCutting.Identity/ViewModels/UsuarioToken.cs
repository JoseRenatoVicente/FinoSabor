using System.Collections.Generic;

namespace SistemaERP.Infra.CrossCutting.Identity.ViewModels
{
    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }
}

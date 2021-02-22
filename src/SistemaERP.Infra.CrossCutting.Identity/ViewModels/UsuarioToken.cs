using SistemaERP.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace SistemaERP.Infra.CrossCutting.Identity.ViewModels
{
    public class UsuarioToken
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }
}

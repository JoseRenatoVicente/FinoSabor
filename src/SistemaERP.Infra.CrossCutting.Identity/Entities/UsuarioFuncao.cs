using Microsoft.AspNetCore.Identity;
using System;

namespace SistemaERP.Infra.CrossCutting.Identity.Entities
{
    public class UsuarioFuncao : IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; }
        public override Guid RoleId { get; set; }
        public Usuario Usuarios { get; set; }
        public Funcao Funcao { get; set; }

    }
}

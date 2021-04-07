using Microsoft.AspNetCore.Identity;
using System;

namespace FinoSabor.Domain.Entities.Identity
{
    public class UsuarioFuncao : IdentityUserRole<Guid>
    {
        public virtual Usuario User { get; set; }
        public virtual Funcao Role { get; set; }


    }
}

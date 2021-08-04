using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities.Identity
{
    [Serializable]
    public class Funcao : IdentityRole<Guid>
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        public virtual ICollection<UsuarioFuncao> UserRoles { get; set; }
    }
}

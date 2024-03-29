﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.Entities.Identity
{
    public class Usuario : IdentityUser<Guid>
    {
        public Usuario()
        {

        }


        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<UsuarioFuncao> UserRoles { get; set; }

        public Pessoa Pessoa { get; set; }

        //public virtual ICollection<IdentityUserRole<int>> Roless { get; } = new List<IdentityUserRole<int>>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        //public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; } = new List<IdentityUserClaim<Guid>>();

        /// <summary>
        /// Navigation property for this users login accounts.
        /// </summary>
        //public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; } = new List<IdentityUserLogin<Guid>>();

        //public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }

    }
}

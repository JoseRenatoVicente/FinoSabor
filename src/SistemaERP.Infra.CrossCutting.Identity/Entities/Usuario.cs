using Microsoft.AspNetCore.Identity;
using System;

namespace SistemaERP.Infra.CrossCutting.Identity.Entities
{
    public class Usuario : IdentityUser
    {
        public Usuario()
        {
            DataCadastro = DateTime.Now;
        }

        public string Nome { get; set; }
        public DateTime DataCadastro { get; private set; }
    }
}

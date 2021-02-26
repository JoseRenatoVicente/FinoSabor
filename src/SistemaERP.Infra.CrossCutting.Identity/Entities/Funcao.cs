using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaERP.Infra.CrossCutting.Identity.Entities
{
    [Serializable]
    public class Funcao : IdentityRole<Guid>
    {
        public Funcao(string name) : base(name)
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        public int VersionNumber { get; set; }
        public string Metadata { get; set; }
        public string Slug { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid CreateBy { get; set; }
        public Guid ModifyBy { get; set; }
        public int Status { get; set; }

        public virtual ICollection<UsuarioFuncao> UserRoles { get; } = new List<UsuarioFuncao>();
    }
}

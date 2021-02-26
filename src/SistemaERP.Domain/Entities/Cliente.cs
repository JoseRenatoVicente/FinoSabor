using Microsoft.AspNetCore.Identity;
using SistemaERP.Domain.Entities.Base;
using SistemaERP.Infra.CrossCutting.Identity.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaERP.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public Cliente()
        {
                
        }

        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; }

        /*public Guid id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }*/
    }
}

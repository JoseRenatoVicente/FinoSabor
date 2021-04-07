using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public Pessoa()
        {
                
        }

        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; }

        public Guid id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
    }
}

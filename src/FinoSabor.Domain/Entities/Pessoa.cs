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

        public string Nome { get; set; }
        public string telefone { get; set; }
        public DateTime data_cadastro { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public Guid id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
    }
}

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
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}

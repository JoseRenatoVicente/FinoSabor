using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.ViewModels.Pessoa
{
    public class PessoaUpdateViewModel : EntityBase
    {
        public string Nome { get; set; }
        public string telefone { get; set; }
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
    }
}

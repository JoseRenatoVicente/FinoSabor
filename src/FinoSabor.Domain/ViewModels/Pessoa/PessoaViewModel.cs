using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.ViewModels.Pessoa
{
    public class PessoaViewModel : EntityBase
    {

        public string Nome { get; set; }
        public string telefone { get; set; }
        public DateTime data_cadastro { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; }
    }
}

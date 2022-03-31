using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.Entities
{
    public class Fornecedor : EntityBase
    {
        public Fornecedor()
        {
        }

        public Fornecedor(string nome, string cnpj, bool ativo, Guid enderecoId)
        {
            Nome = nome;
            Cnpj = cnpj;
            Ativo = ativo;
            EnderecoId = enderecoId;
        }

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }

        public Guid EnderecoId { get; set; }

        /* EF Relation */
        public EnderecoFornecedor Endereco { get; set; }

    }
}

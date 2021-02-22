using SistemaERP.Domain.Entities.Base;
using SistemaERP.Domain.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaERP.Domain.Entities
{
    public class Fornecedor : EntityBase
    {
        public Fornecedor()
        {
        }

        public Fornecedor(string nome, string documento, TipoFornecedor tipoFornecedor, bool situacao)
        {
            Nome = nome;
            Documento = documento;
            TipoFornecedor = tipoFornecedor;
            Situacao = situacao;
        }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public FornecedorEndereco Endereco { get; set; }
        public bool Situacao { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}

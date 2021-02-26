using SistemaERP.Domain.Entities.Base;
using SistemaERP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaERP.Domain.Entities
{
    public class Fornecedor : EntityBase
    {
        public Fornecedor()
        {
        }

        public Fornecedor(string nome, TipoFornecedor tipo_fornecedor, string documento, bool situacao, Guid id_endereco)
        {
            this.nome = nome;
            this.tipo_fornecedor = tipo_fornecedor;
            this.documento = documento;
            this.situacao = situacao;
            this.id_endereco = id_endereco;
        }

        public string nome { get; set; }
        public TipoFornecedor tipo_fornecedor { get; set; }
        public string documento { get; set; }
        public bool situacao { get; set; }
        public Guid id_endereco { get; set; }

        /* EF Relations */
        [ForeignKey("id_endereco")]
        public Endereco_Fornecedor Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}

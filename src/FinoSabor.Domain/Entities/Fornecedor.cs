using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Fornecedor : EntityBase
    {
        public Fornecedor()
        {
        }

        public Fornecedor(string nome, string cnpj, bool ativo, Guid id_endereco)
        {
            this.nome = nome;
            this.cnpj = cnpj;
            this.ativo = ativo;
            this.id_endereco = id_endereco;
        }

        public string nome { get; set; }
        public string cnpj { get; set; }
        public bool ativo { get; set; }

        public Guid id_endereco { get; set; }

        /* EF Relation */
        [ForeignKey("id_endereco")]
        public Endereco_Fornecedor Endereco { get; set; }
        
    }
}

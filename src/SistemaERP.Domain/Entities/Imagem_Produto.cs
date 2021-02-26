using SistemaERP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaERP.Domain.Entities
{
    public class Imagem_Produto : EntityBase
    {


        public Imagem_Produto()
        {

        }

        public Imagem_Produto(string caminho, Guid id_produto)
        {
            this.caminho = caminho;
            this.id_produto = id_produto;
        }

        public string caminho { get; set; }

        //Banco de dados
        public Guid id_produto { get; set; }

        //EF Relation
        [ForeignKey("id_produto")]
        public Produto Produto { get; set; }
    }
}

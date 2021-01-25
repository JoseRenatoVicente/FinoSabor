using SistemaERP.Domain.Entities.Base;
using System;

namespace SistemaERP.Domain.Entities
{
    public class Imagem : EntityBase
    {


        public Imagem()
        {
                
        }

        public Imagem(string caminho, Guid produtoId)
        {
            Caminho = caminho;
            ProdutoId = produtoId;
        }

        public string Caminho { get; set; }

        //Banco de dados
        public Guid ProdutoId { get; set; }

        //EF Relation
        public Produto Produto { get; set; }
    }
}

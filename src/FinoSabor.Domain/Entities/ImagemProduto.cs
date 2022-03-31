using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.Entities
{
    public class ImagemProduto : EntityBase
    {


        public ImagemProduto()
        {

        }

        public ImagemProduto(string caminho, Guid produtoId)
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

using FinoSabor.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class ItensCompra : EntityBase
    {
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        //Banco de dados
        public Guid IdCompra { get; set; }
        public Guid IdProduto { get; set; }

        //EF Relation
        public Compra Compra { get; set; }
        public Produto Produto { get; set; }
    }
}

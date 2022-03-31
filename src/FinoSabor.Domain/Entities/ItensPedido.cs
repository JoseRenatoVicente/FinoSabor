using FinoSabor.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class ItensPedido : EntityBase
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        [NotMapped] public decimal ValorItem { get; set; }

        //Banco de dados
        public Guid ProdutoId { get; set; }
        public Guid PedidoId { get; set; }

        //EF Relation
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}

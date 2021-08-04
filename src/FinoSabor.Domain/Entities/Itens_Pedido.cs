using FinoSabor.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Itens_Pedido : EntityBase
    {
        public decimal valor_unitario { get; set; }
        public int quantidade { get; set; }

        [NotMapped] public decimal valor_item { get; set; }

        //Banco de dados
        public Guid id_produto { get; set; }
        public Guid id_pedido { get; set; }

        //EF Relation
        [ForeignKey("id_produto")]
        public Produto Produto { get; set; }
        [ForeignKey("id_pedido")]
        public Pedido Pedido { get; set; }
    }
}

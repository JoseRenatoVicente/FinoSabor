using FinoSabor.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Itens_Compra : EntityBase
    {
        public int quantidade { get; set; }
        public int valor_unitario { get; set; }
        [NotMapped] public decimal valor_item { get; set; }

        //Banco de dados
        public Guid id_compra { get; set; }
        public Guid id_produto { get; set; }

        //EF Relation
        [ForeignKey("id_compra")]
        public Compra Compra { get; set; }

        [ForeignKey("id_produto")]
        public Produto Produto { get; set; }
    }
}

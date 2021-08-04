using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Compra : EntityBase
    {
        public DateTime data { get; set; } = DateTime.UtcNow;

        public StatusCompra status_compra { get; set; }
        //Banco de dados
        public Guid id_fornecedor { get; set; }

        //EF Relation
        [ForeignKey("id_fornecedor")]
        public Fornecedor Fornecedor { get; set; }

        /* EF Relations */
        public ICollection<Itens_Compra> Itens { get; set; }
    }
}

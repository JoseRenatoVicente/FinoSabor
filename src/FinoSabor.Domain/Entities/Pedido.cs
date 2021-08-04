using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using FinoSabor.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Pedido : EntityBase
    {
        public DateTime data_pedido { get; set; } = DateTime.UtcNow;
        public StatusPedido status { get; set; }
        public FormaPagamento forma_pagamento { get; set; }
        public Guid id_usuario { get; set; }
        [NotMapped] public decimal Total { get; set; }

        
        /* EF Relations */
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        public IEnumerable<Itens_Pedido> Itens { get; set; }
    }
}

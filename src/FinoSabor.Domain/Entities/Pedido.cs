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
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;
        public StatusPedido Status { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        [NotMapped] public decimal Total { get; set; }
        public Guid UsuarioId { get; set; }

        /* EF Relations */
        public Usuario Usuario { get; set; }
        public IEnumerable<ItensPedido> Itens { get; set; }
    }
}

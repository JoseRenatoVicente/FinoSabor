using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;

namespace FinoSabor.Domain.ViewModels
{
    public class PedidoViewModel : EntityBase
    {
        public DateTime data_pedido { get; set; }
        public StatusPedido status { get; set; }
        public FormaPagamento forma_pagamento { get; set; }
        public decimal Total { get; set; }

    }
}

using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.ViewModels
{
    public class PedidoDetalhadoViewModel : EntityBase
    {
        public DateTime data_pedido { get; set; }
        public StatusPedido status { get; set; }
        public FormaPagamento forma_pagamento { get; set; }
        public decimal Total { get; set; }

        public Guid id_usuario { get; set; }

        public IEnumerable<Itens_PedidoViewModel> Itens { get; set; }
    }
}

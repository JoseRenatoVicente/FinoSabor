using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.ViewModels.Cliente.Pedido
{
    public class PedidoInsertViewModel : EntityBase
    {
        public FormaPagamento forma_pagamento { get; set; }
        public Guid id_usuario { get; set; }

        public IEnumerable<Itens_PedidoInsertViewModel> Itens { get; set; }
    }
}

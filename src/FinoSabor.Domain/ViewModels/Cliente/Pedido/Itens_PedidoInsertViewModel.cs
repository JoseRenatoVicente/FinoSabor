using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.ViewModels.Cliente.Pedido
{
    public class Itens_PedidoInsertViewModel : EntityBase
    {
        public int quantidade { get; set; }

        //Banco de dados
        public Guid id_produto { get; set; }
        public Guid id_pedido { get; set; }
    }
}

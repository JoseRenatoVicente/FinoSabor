using FinoSabor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Domain.ViewModels
{
    public class Itens_PedidoViewModel : EntityBase
    {
        public decimal valor_unitario { get; set; }
        public int quantidade { get; set; }
        public decimal valor_item { get; set; }
        public string nomeProduto { get; set; }

        //Banco de dados
        public Guid id_produto { get; set; }
        public Guid id_pedido { get; set; }

    }
}

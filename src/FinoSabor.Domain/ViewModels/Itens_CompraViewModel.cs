using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.ViewModels
{
    public class Itens_CompraViewModel : EntityBase
    {
        public int quantidade { get; set; }
        public decimal valor_unitario { get; set; }
        //Campo a ser calculado
        public decimal valor_item { get; set; }

        //Banco de dados
        public Guid id_produto { get; set; }

        public string nomeProduto{ get; set; }
    }
}

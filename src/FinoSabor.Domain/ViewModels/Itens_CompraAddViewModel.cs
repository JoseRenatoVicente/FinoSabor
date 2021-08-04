using FinoSabor.Domain.Entities.Base;
using System;

namespace FinoSabor.Domain.ViewModels
{
    public class Itens_CompraAddViewModel : EntityBase
    {
        public int quantidade { get; set; }
        public decimal valor_unitario { get; set; }

        //Banco de dados
        public Guid id_produto { get; set; }
    }
}

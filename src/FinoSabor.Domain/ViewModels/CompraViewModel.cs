using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;

namespace FinoSabor.Domain.ViewModels
{
    public class CompraViewModel : EntityBase
    {
        public DateTime data { get; set; }
        public StatusCompra status_compra { get; set; }

        //Banco de dados
        public string nomeFornecedor { get; set; }

        //Valor a ser calculado
        public decimal Total { get; set; }

        /* EF Relations */
    }
}

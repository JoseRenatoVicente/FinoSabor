using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.ViewModels
{
    public class CompraAddViewModel : EntityBase
    {
        public DateTime data { get; set; }
        public StatusCompra status_compra { get; set; }
        //Banco de dados
        public Guid id_fornecedor { get; set; }

        /* EF Relations */
        public ICollection<Itens_CompraAddViewModel> Itens { get; set; }
    }
}

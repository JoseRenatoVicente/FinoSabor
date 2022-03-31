using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.ViewModels
{
    public class CompraDetalhadaViewModel : EntityBase
    {
        public DateTime data { get; set; }
        public StatusCompra status_compra { get; set; }
        //Banco de dados
        public string nomeFornecedor { get; set; }
        public Guid id_fornecedor { get; set; }

        //Valor a ser calculado
        public decimal Total { get; set; }

        /* EF Relations */
        public IEnumerable<Itens_CompraViewModel> Itens { get; set; }
    }
}

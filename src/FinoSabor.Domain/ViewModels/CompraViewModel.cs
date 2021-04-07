using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Domain.ViewModels
{
    public class CompraViewModel : EntityBase
    {
        public DateTime data { get; set; }


        [NotMapped] public decimal Total { get; set; }
        
        //Banco de dados
        public Guid id_fornecedor { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }

        /* EF Relations */
        public IEnumerable<Itens_Compra> Itens { get; set; }
    }
}

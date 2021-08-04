using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
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
        public StatusCompra status_compra { get; set; }

        //Banco de dados
        public string nomeFornecedor{ get; set; }

        //Valor a ser calculado
        public decimal Total { get; set; }

        /* EF Relations */
    }
}

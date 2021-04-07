using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Application.ViewModels
{
    public class FornecedorViewModel : EntityBase
    {
        public string nome { get; set; }
        public string cnpj { get; set; }
        public bool ativo { get; set; }

    }
}

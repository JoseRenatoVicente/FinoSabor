using FinoSabor.Domain.Entities.Base;

namespace FinoSabor.Application.ViewModels
{
    public class FornecedorViewModel : EntityBase
    {
        public string nome { get; set; }
        public string cnpj { get; set; }
        public bool ativo { get; set; }

    }
}

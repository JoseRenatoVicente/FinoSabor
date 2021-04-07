using System.Collections.Generic;

namespace FinoSabor.Domain.ViewModels.Frete
{
    public class Frete
    {
        public int CEP { get; set; }
        //CodCarrinho - HashCode MD5.
        public string CodCarrinho { get; set; }
        public List<ValorPrazoFrete> ListaValores { get; set; }
    }
}

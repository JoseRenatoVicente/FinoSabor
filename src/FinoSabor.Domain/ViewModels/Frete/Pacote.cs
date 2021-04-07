using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Domain.ViewModels.Frete
{
    public class Pacote
    {
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }
        public double Peso { get; set; }
    }
}

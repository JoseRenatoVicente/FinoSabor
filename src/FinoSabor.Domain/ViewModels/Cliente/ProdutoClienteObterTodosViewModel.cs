using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.ViewModels.Cliente
{
    public class ProdutoClienteObterTodosViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string slug { get; set; }
        public string imagem_principal { get; set; }

        //public List<ImagemViewModel> Imagem { get; set; }
    }
}

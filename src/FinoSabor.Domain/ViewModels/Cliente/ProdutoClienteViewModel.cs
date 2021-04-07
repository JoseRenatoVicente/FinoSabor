using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Application.ViewModels.Cliente
{
    public class ProdutoClienteViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
        public string slug { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCategoria { get; set; }

        public string SlugCategoria { get; set; }

        public string imagem_principal { get; set; }
        public IEnumerable<ImagemViewModel> Imagem { get; set; }


    }
}

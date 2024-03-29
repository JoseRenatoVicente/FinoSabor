﻿using FinoSabor.Domain.Entities.Base;

namespace FinoSabor.Application.ViewModels.Cliente
{
    public class ProdutoClienteObterTodosViewModel : EntityBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string slug { get; set; }
        public string imagem_principal { get; set; }

        //public List<ImagemViewModel> Imagem { get; set; }
    }
}

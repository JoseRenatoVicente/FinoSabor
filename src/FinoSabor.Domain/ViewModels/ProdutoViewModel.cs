using FinoSabor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Application.ViewModels
{
    public class ProdutoViewModel : EntityBase
    {
        public string nome { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public int quantidade_estoque { get; set; }
        public int quantidade_minima { get; set; }
        public double peso { get; set; }
        public int largura { get; set; }
        public int altura { get; set; }
        public int comprimento { get; set; }
        public string slug { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCategoria { get; set; }
        public string imagem_principal { get; set; }

        public IEnumerable<ImagemViewModel> Imagem { get; set; }


        //Banco de dados
        public Guid id_categoria { get; set; }


    }
}

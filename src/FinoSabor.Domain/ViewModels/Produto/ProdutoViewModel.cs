using FinoSabor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinoSabor.Application.ViewModels
{
    public class ProdutoViewModel : EntityBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Slug { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCategoria { get; set; }
        public string ImagemPrincipal { get; set; }

        public IEnumerable<ImagemViewModel> Imagem { get; set; }


        //Banco de dados
        public Guid CategoriaId { get; set; }
    }
}

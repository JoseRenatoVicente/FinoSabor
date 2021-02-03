using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaERP.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeEstoque { get; set; }
        public double Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }

        //public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public string NomeFornecedor { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCategoria { get; set; }

        //public IEnumerable<Imagem> Imagem { get; set; }


        //Banco de dados
        public Guid FornecedorId { get; set; }
        public Guid CategoriaId { get; set; }


    }
}

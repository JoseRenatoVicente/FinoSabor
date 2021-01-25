using SistemaERP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaERP.Domain.Entities
{
    public class Produto : EntityBase
    {
        public Produto()
        {
        }

        public Produto(string nome, decimal valor, string descricao, bool ativo, int quantidadeEstoque, double peso, int largura, int altura, int comprimento, DateTime dataCadastro, Guid fornecedorId, Guid categoriaId)
        {
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
            Ativo = ativo;
            QuantidadeEstoque = quantidadeEstoque;
            Peso = peso;
            Largura = largura;
            Altura = altura;
            Comprimento = comprimento;
            DataCadastro = dataCadastro;
            FornecedorId = fornecedorId;
            CategoriaId = categoriaId;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeEstoque { get; set; }
        public double Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }

        public DateTime DataCadastro { get; set; }


        //Banco de dados
        public Guid FornecedorId { get; set; }
        public Guid CategoriaId { get; set; }

        //EF Relation
        public Fornecedor Fornecedor { get; set; }
        public Categoria Categoria { get; set; }


        public IEnumerable<Imagem> Imagem { get; set; }

        public void RetirarEstoque(int quantidade)
        {
            if (QuantidadeEstoque >= quantidade)
                QuantidadeEstoque -= quantidade;
        }

        public bool EstaDisponivel(int quantidade)
        {
            return Ativo && QuantidadeEstoque >= quantidade;
        }


    }
}

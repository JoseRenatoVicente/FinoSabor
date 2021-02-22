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

        public Produto(string nome, decimal valor, string descricao, bool situacao, int quantidadeEstoque, double peso, int largura, int altura, int comprimento, Guid fornecedorId, Guid categoriaId)
        {
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
            Situacao = situacao;
            QuantidadeEstoque = quantidadeEstoque;
            Peso = peso;
            Largura = largura;
            Altura = altura;
            Comprimento = comprimento;
            FornecedorId = fornecedorId;
            CategoriaId = categoriaId;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        public bool Situacao { get; set; }

	    //public string Slug { get; set; }
        public int QuantidadeEstoque { get; set; }
        public double Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }


        //Banco de dados
        public Guid FornecedorId { get; set; }
        public Guid CategoriaId { get; set; }

        //EF Relation
        public Fornecedor Fornecedor { get; set; }
        public Categoria Categoria { get; set; }


        public IEnumerable<ProdutoImagem> Imagem { get; set; }

        public void RetirarEstoque(int quantidade)
        {
            if (QuantidadeEstoque >= quantidade)
                QuantidadeEstoque -= quantidade;
        }

        public bool EstaDisponivel(int quantidade)
        {
            return Situacao && QuantidadeEstoque >= quantidade;
        }


    }
}

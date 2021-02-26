using SistemaERP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaERP.Domain.Entities
{
    public class Produto : EntityBase
    {
        public Produto()
        {
        }

        public Produto(string nome, decimal valor, string descricao, bool situacao, int quantidade_estoque, double peso, int largura, int altura, int comprimento, Guid id_fornecedor, Guid id_categoria)
        {
            this.nome = nome;
            this.valor = valor;
            this.descricao = descricao;
            this.situacao = situacao;
            this.quantidade_estoque = quantidade_estoque;
            this.peso = peso;
            this.largura = largura;
            this.altura = altura;
            this.comprimento = comprimento;
            this.id_fornecedor = id_fornecedor;
            this.id_categoria = id_categoria;
        }

        public string nome { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public bool situacao { get; set; }
	    //public string slug { get; set; }
        public int quantidade_estoque { get; set; }
        public double peso { get; set; }
        public int largura { get; set; }
        public int altura { get; set; }
        public int comprimento { get; set; }


        //Banco de dados
        public Guid id_fornecedor { get; set; }
        public Guid id_categoria { get; set; }

        //EF Relation
        [ForeignKey("id_fornecedor")]
        public Fornecedor Fornecedor { get; set; }
        [ForeignKey("id_categoria")]
        public Categoria Categoria { get; set; }


        public IEnumerable<Imagem_Produto> Imagem { get; set; }

        public void RetirarEstoque(int quantidade)
        {
            if (quantidade_estoque >= quantidade)
                quantidade_estoque -= quantidade;
        }

        public bool EstaDisponivel(int quantidade)
        {
            return situacao && quantidade_estoque >= quantidade;
        }
    }
}

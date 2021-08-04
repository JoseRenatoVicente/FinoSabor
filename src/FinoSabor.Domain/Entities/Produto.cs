using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinoSabor.Domain.Entities
{
    public class Produto : EntityBase
    {
        public Produto()
        {
        }

        public Produto(string nome, decimal valor, string descricao, bool ativo, int quantidade_estoque, int quantidade_minima, double peso, int largura, int altura, int comprimento, Guid id_categoria)
        {
            this.nome = nome;
            this.valor = valor;
            this.descricao = descricao;
            this.ativo = ativo;
            this.quantidade_estoque = quantidade_estoque;
            this.quantidade_minima = quantidade_minima;
            //TODO:checar
            slug = nome.Slugify();
            this.id_categoria = id_categoria;
        }

        public string nome { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public string imagem_principal { get; set; }
        public bool ativo { get; set; }
        public int quantidade_estoque { get; set; }
        public int quantidade_minima { get; set; }
	    public string slug { get; set; }

        public Guid id_categoria { get; set; }

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
            return ativo && quantidade_estoque >= quantidade;
        }
    }
}

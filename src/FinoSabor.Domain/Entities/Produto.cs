using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace FinoSabor.Domain.Entities
{
    public class Produto : EntityBase
    {
        public Produto()
        {
        }

        public Produto(string nome, decimal valor, string descricao, string imagemPrincipal, bool ativo, int quantidadeEstoque, int quantidadeMinima, string slug, Guid idCategoria)
        {
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
            ImagemPrincipal = imagemPrincipal;
            Ativo = ativo;
            QuantidadeEstoque = quantidadeEstoque;
            QuantidadeMinima = quantidadeMinima;
            //TODO:checar
            Slug = nome.Slugify();
            IdCategoria = idCategoria;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string ImagemPrincipal { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; }
	    public string Slug { get; set; }

        public Guid IdCategoria { get; set; }
        public Categoria Categoria { get; set; }


        public IEnumerable<ImagemProduto> Imagem { get; set; }

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

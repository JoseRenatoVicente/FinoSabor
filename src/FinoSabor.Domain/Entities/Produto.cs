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

        public Produto(string nome, decimal valor, string descricao, string imagemPrincipal, bool ativo, int quantidadeEstoque, int quantidadeMinima, Guid categoriaId)
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
            CategoriaId = categoriaId;
        }

        public Produto(string nome, decimal valor, string descricao, string imagemPrincipal, bool ativo, int quantidadeEstoque, int quantidadeMinima, Guid categoriaId, Guid id) : this(nome, valor, descricao, imagemPrincipal, ativo, quantidadeEstoque, quantidadeMinima, categoriaId)
        {
            Id = id;
        }


        public string Nome { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string ImagemPrincipal { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Excluido { get; set; } = false;
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Slug { get; set; }

        public Guid CategoriaId { get; set; }
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

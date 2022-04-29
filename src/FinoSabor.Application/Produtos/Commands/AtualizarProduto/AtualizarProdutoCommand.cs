using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Messages;
using MediatR;
using System;

namespace FinoSabor.Application.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string ImagemPrincipal { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; }
        public Guid CategoriaId { get; set; }
    }
}

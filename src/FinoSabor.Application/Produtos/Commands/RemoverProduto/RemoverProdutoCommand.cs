using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Messages;
using MediatR;
using System;

namespace FinoSabor.Application.Produtos.Commands.RemoverProduto
{
    public class RemoverProdutoCommand : Command
    {
        public Guid Id { get; set; }
    }
}

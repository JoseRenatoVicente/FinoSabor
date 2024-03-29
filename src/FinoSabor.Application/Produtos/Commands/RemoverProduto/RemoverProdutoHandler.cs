﻿using FinoSabor.Domain.Core.Messages;
using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Application.Produtos.Commands.RemoverProduto
{
    public class RemoverProdutoHandler : CommandHandler, IRequestHandler<RemoverProdutoCommand, ValidationResult>
    {
        private readonly IProdutoRepository _produtoRepository;

        public RemoverProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ValidationResult> Handle(RemoverProdutoCommand request, CancellationToken cancellationToken)
        {
            Produto produto = await _produtoRepository.GetByIdAsync(request.Id);

            if (produto is null)
            {
                AdicionarErro("Produto não encontrado");
                return ValidationResult;
            }

            produto.Excluido = true;

            await _produtoRepository.UpdateAsync(produto);

            return ValidationResult;
        }
    }
}

using FinoSabor.Domain.Core.Messages;
using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Application.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoHandler : CommandHandler, IRequestHandler<AtualizarProdutoCommand, BaseResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public AtualizarProdutoHandler(IProdutoRepository repositoryProduto, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = repositoryProduto;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<BaseResponse> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!await _produtoRepository.Existe(c => c.Id == request.Id))
            {
                AdicionarErro("Produto não encontrado");
                return new BaseResponse(ValidationResult);
            }

            Produto produto = new Produto(request.Nome, request.Valor, request.Descricao, request.ImagemPrincipal, request.Ativo, request.QuantidadeEstoque, request.QuantidadeMinima, request.CategoriaId, request.Id);

            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return new BaseResponse(ValidationResult);

            if (!await _categoriaRepository.Existe(c => c.Id == produto.CategoriaId))
            {
                AdicionarErro("Categoria não encontrada");
                return new BaseResponse(ValidationResult);
            }

            await _produtoRepository.UpdateAsync(produto);

            return new BaseResponse(produto);
        }
    }
}

using FinoSabor.Domain.Core.Messages;
using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Application.Produtos.Commands.AdicionarProduto
{
    public class AdicionarProdutoHandler : CommandHandler, IRequestHandler<AdicionarProdutoCommand, BaseResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public AdicionarProdutoHandler(IProdutoRepository repositoryProduto, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = repositoryProduto;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<BaseResponse> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            Produto produto = new Produto(request.Nome, request.Valor, request.Descricao, request.ImagemPrincipal, request.Ativo, request.QuantidadeEstoque, request.QuantidadeMinima, request.CategoriaId);

            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return new BaseResponse(ValidationResult);

            if (!await _categoriaRepository.Existe(c => c.Id == produto.CategoriaId))
            {
                AdicionarErro("Categoria não encontrada");
                return new BaseResponse(ValidationResult);
            }

            if (await _produtoRepository.Existe(c => c.Slug == produto.Slug))
            {
                AdicionarErro("Já existe um produto com o nome " + request.Nome);
                return new BaseResponse(ValidationResult);
            }

            await _produtoRepository.AddAsync(produto);

            return new BaseResponse(produto);
        }
    }
}

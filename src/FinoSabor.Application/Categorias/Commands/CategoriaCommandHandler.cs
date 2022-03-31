using FinoSabor.Domain.Core.Messages;
using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Application.Categorias.Commands
{
    public class CategoriaCommandHandler : CommandHandler, 
        IRequestHandler<AdicionarCategoriaCommand, BaseResponse>,
        IRequestHandler<AtualizarCategoriaCommand, BaseResponse>
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<BaseResponse> Handle(AdicionarCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria categoria = new Categoria(request.Nome);

            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return new BaseResponse(ValidationResult); ;

            if (await _categoriaRepository.Existe(c => c.Slug == categoria.Slug))
            {
                AdicionarErro("Já existe uma categoria com o nome " + categoria.Nome);
                return new BaseResponse(ValidationResult);
            }

            await _categoriaRepository.AddAsync(categoria);

            return new BaseResponse(categoria);
        }

        public async Task<BaseResponse> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
        {

            Categoria categoria = new Categoria(request.Nome, request.Slug);

            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return new BaseResponse(ValidationResult); 

            await _categoriaRepository.UpdateAsync(categoria);

            if (await _categoriaRepository.Existe(c => c.Slug == categoria.Slug))
            {
                AdicionarErro("Já existe uma categoria com o Slug " + categoria.Slug);
                return new BaseResponse(ValidationResult);
            }

            return new BaseResponse(categoria);
        }

        public async Task<BaseResponse> Handle(RemoverCategoriaCommand request, CancellationToken cancellationToken)
        {
            await _categoriaRepository.DeleteAsync(request.Id);

            if (await _categoriaRepository.Existe(c => c.Id == request.Id))
            {
                AdicionarErro("Categoria não encontrada");
                return new BaseResponse(ValidationResult);
            }

            return new BaseResponse();
        }
    }
}

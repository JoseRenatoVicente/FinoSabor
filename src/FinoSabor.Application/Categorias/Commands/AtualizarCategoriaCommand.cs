using FinoSabor.Domain.Core.Responses;
using MediatR;

namespace FinoSabor.Application.Categorias.Commands
{

    public class AtualizarCategoriaCommand : IRequest<BaseResponse>
    {
        public string Nome { get; set; }
        public string Slug { get; set; }
    }

}
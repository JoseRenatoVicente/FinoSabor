using FinoSabor.Domain.Core.Responses;
using MediatR;

namespace FinoSabor.Application.Categorias.Commands
{
    public class AdicionarCategoriaCommand : IRequest<BaseResponse>
    {
        public string Nome { get; set; }
    }
}

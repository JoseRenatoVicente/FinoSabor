using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities.Base;
using MediatR;

namespace FinoSabor.Application.Categorias.Commands
{
    public class RemoverCategoriaCommand : EntityBase, IRequest<BaseResponse>
    {
    }
}

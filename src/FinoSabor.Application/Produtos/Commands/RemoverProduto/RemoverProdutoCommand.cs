using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities.Base;
using MediatR;

namespace FinoSabor.Application.Produtos.Commands.RemoverProduto
{
    public class RemoverProdutoCommand : EntityBase, IRequest<BaseResponse>
    {
    }
}

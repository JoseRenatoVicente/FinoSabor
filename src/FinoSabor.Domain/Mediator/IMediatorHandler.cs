using FluentValidation.Results;
using System.Threading.Tasks;
using MediatR;
using FinoSabor.Domain.Messages;

namespace FinoSabor.Domain.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> Send<T>(T comando) where T : Command;
    }

}

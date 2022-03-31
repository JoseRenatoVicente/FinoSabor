using FinoSabor.Domain.Entities;
using FluentValidation;

namespace FinoSabor.Domain.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(c => c.FormaPagamento).NotNull()
                .WithMessage("O campo Forma de pagamento precisa ser fornecido");
        }
    }
}

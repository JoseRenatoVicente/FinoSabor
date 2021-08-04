using FluentValidation;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Domain.Validations
{
    public class Itens_PedidoValidation : AbstractValidator<Itens_Pedido>
    {
        public Itens_PedidoValidation()
        {
            RuleFor(c => c.quantidade)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}

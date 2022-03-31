using FinoSabor.Domain.Entities;
using FluentValidation;

namespace FinoSabor.Domain.Validations
{
    public class Itens_PedidoValidation : AbstractValidator<ItensPedido>
    {
        public Itens_PedidoValidation()
        {
            RuleFor(c => c.Quantidade)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}

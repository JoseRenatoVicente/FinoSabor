using FinoSabor.Domain.Entities;
using FluentValidation;

namespace FinoSabor.Domain.Validations
{
    public class Itens_CompraValidation : AbstractValidator<Itens_Compra>
    {
        public Itens_CompraValidation()
        {
            RuleFor(c => c.quantidade)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.valor_unitario)
             .NotEmpty().WithMessage("O campo valor precisa ser fornecido")
             .GreaterThan(0).WithMessage("O campo valor precisa ser maior que {ComparisonValue}");

        }
    }
}

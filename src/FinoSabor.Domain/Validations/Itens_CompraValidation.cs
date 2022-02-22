using FinoSabor.Domain.Entities;
using FluentValidation;

namespace FinoSabor.Domain.Validations
{
    public class Itens_CompraValidation : AbstractValidator<ItensCompra>
    {
        public Itens_CompraValidation()
        {
            RuleFor(c => c.Quantidade)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.ValorUnitario)
             .NotEmpty().WithMessage("O campo valor precisa ser fornecido")
             .GreaterThan(0).WithMessage("O campo valor precisa ser maior que {ComparisonValue}");

        }
    }
}

using FluentValidation;
using FinoSabor.Domain.Entities;
using System;

namespace FinoSabor.Domain.Validations
{
    public class CompraValidation : AbstractValidator<Compra>
    {
        public CompraValidation()
        {
            RuleFor(c => c.id_fornecedor)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do Fornecedor inválido");

        }
    }
}

using FinoSabor.Domain.Entities;
using FluentValidation;
using System;

namespace FinoSabor.Domain.Validations
{
    public class CompraValidation : AbstractValidator<Compra>
    {
        public CompraValidation()
        {
            RuleFor(c => c.FornecedorId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do Fornecedor inválido");

        }
    }
}

using FluentValidation;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Domain.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(c => c.forma_pagamento).NotNull()
                .WithMessage("O campo Forma de pagamento precisa ser fornecido");
        }
    }
}

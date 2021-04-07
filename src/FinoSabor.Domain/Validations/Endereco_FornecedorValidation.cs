using FluentValidation;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Domain.Validations
{
    public class Endereco_FornecedorValidation : AbstractValidator<Endereco_Fornecedor>
    {
        public Endereco_FornecedorValidation()
        {
            RuleFor(c => c.rua)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

            RuleFor(c => c.cidade)
                .NotEmpty().WithMessage("A campo {PropertyName} precisa ser fornecida")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.estado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.numero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}

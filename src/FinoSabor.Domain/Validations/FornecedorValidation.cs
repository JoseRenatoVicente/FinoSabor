using FluentValidation;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Enums;
using FinoSabor.Domain.Validations.cnpjs;

namespace FinoSabor.Domain.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");



            RuleFor(f => f.cnpj.Length).Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage("O campo cnpj precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CnpjValidacao.Validar(f.cnpj)).Equal(true)
                .WithMessage("O cnpj fornecido é inválido.");

        }
    }
}

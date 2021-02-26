using FluentValidation;
using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Entities.Enums;
using SistemaERP.Domain.Validations.Documentos;

namespace SistemaERP.Domain.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.tipo_fornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(f => f.documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CpfValidacao.Validar(f.documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

            When(f => f.tipo_fornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidacao.Validar(f.documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}

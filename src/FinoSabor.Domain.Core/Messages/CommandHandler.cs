using FluentValidation;
using FluentValidation.Results;

namespace FinoSabor.Domain.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados()
        {

            return ValidationResult;
        }

        public bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE>
        {
            ValidationResult = validacao.Validate(entidade);
            return ValidationResult.IsValid;
        }

    }
}

using FluentValidation.Results;

namespace FinoSabor.Domain.Core.Responses
{
    public class BaseResponse
    {
        public BaseResponse() => isSuccess = true;
        public BaseResponse(Object entity)
        {
            isSuccess = true;
            Entity = entity;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            isSuccess = false;

            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            errors.Add(erro);
        }

        public bool isSuccess { get; set; }
        public ICollection<string> errors = new List<string>();
        public Object Entity { get; set; }
    }
}

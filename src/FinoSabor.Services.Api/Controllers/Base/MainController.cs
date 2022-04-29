using FinoSabor.Domain.Core.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Base
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly ICollection<string> _errors = new List<string>();

        protected async Task<ActionResult> CustomResponseAsync(object result = null)
        {
            if (await IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                success = false,
                errors = _errors.ToArray()
            });
        }

        protected async Task<ActionResult> CustomResponseAsync(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                await AddError(erro.ErrorMessage);
            }

            return await CustomResponseAsync();
        }

        protected async Task<ActionResult> CustomResponseAsync(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                await AddError(erro.ErrorMessage);
            }

            return await CustomResponseAsync();
        }

        protected ActionResult CustomResponseAsync(BaseResponse baseResponse)
        {
            if (baseResponse.isSuccess)
            {
                return Ok(baseResponse.Entity);
            }

            return BadRequest(new
            {
                success = false,
                errors = baseResponse.errors
            });
        }

        protected Task<bool> IsOperationValid()
        {
            return Task.Run(() => !_errors.Any());
        }

        protected Task AddError(string erro)
        {
            return Task.Run(() => _errors.Add(erro));
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}

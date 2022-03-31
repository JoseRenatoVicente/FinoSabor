using FinoSabor.Domain.Core.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace FinoSabor.Services.Api.Controllers.Base
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponseAsync(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                success = false,
                errors = _errors.ToArray()
            });
        }

        protected ActionResult CustomResponseAsync(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponseAsync();
        }

        protected ActionResult CustomResponseAsync(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponseAsync();
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

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}

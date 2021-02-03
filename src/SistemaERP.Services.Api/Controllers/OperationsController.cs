using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Application.ViewModels;
using SistemaERP.Domain.Helpers;
using System;

namespace SistemaERP.Services.Api.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowAllHeaders")]
    public class OperationsController : Controller
    {
        protected string _validToken;
        IEmailService _emailService;

        public OperationsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [Route("ForceException")]
        public IActionResult ForceException()
        {
            var teste = 1 / Convert.ToInt32("Teste");
            return BadRequest();
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            var result = new
            {
                ServerNow = DateTime.Now,
                SaoPauloNow = DateTimeHelper.ConvertDateTimeSaoPaulo(DateTime.Now),
                ServerToday = DateTime.Today,
                SaoPauloToday = DateTimeHelper.GetTodaySaoPaulo(),
                Message = "Pong!"
            };
            return Ok(result);
        }

        /*[HttpPost("EmailTest")]
        public IActionResult EmailTest([FromBody] EmailTestVM emailVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _emailService.Test(emailVM.Email, emailVM.Name).Wait();
            return Ok();
        }*/

    }
}

using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Helpers;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowAllHeaders")]
    public class OperationsController : MainController
    {
        private readonly IEmailService _emailService;

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

        [HttpPost("EmailTeste")]
        public async Task<IActionResult> EnviarEmailTest(string nome, string email)
        {
            try
            {
                await _emailService.Test(email, nome);
                return CustomResponseAsync("Email enviado com sucesso");
            }
            catch (Exception e)
            {
                AddError("erro ao enviar email, tente novamente mais tarde " + e);
                return CustomResponseAsync();
            }

        }


    }
}

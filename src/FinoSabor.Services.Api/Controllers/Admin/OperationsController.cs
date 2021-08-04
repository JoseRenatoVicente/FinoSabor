using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
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
        IEmailService _emailService;

        public OperationsController(IEmailService emailService,
            INotificador notificador, IAspNetUser appUser) : base(notificador, appUser)
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
                return CustomResponse("Email enviado com sucesso");
            }
            catch (Exception e)
            {
                NotificarErro("erro ao enviar email, tente novamente mais tarde " + e);
                return CustomResponse();
            }

        }


    }
}

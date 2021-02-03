using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Application.ViewModels;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : MainController
    {
        private readonly IEmailService mailService;

        public EmailController(INotificador notificador,
                               IAspNetUser user,
                               IEmailService mailService) : base(notificador, user)
        {
            this.mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterEmail()
        {

            //await mailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
            return Ok();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMailTest([FromForm] EmailRequest request)
        {

            //await mailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
            return Ok();
        }
    }
}

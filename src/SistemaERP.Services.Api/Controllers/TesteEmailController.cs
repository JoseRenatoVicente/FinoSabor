using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TesteEmailController : ControllerBase
    {
        private readonly IEmailService mailService;

        public TesteEmailController(IEmailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMailTest([FromForm] EmailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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

                using (var client = new SmtpClient())
                {
                    MimeMessage mes = new MimeMessage();
                    mes.From.Add(new MailboxAddress("xxx", "xxx@gmail.com"));
                    mes.To.Add(new MailboxAddress("xxx", request.ToEmail));
                    mes.Subject = "hello";
                    mes.Body = new TextPart("plain")
                    {
                        Text = @"hi,
        i'm azure! " + DateTime.Now.ToString()
                    };

                    client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    client.Authenticate("tempforum333@gmail.com", "3t3wi7ez");
                    client.Send(mes);
                    client.Disconnect(true);
                }

                //await mailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

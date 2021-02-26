using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.Data.Repository.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : MainController
    {
        private readonly IEmailService _mailService;
        private readonly IEmailConfigRepository _emailConfigRepository;

        public EmailController(INotificador notificador,
                               IAspNetUser user,
                               IEmailService mailService,
                               IEmailConfigRepository emailConfigRepository) : base(notificador, user)
        {
            _mailService = mailService;
            _emailConfigRepository = emailConfigRepository;
        }

        [HttpGet]
        public async Task<ActionResult<EmailConfig>> ObterEmails()
        {            
            return CustomResponse(await _emailConfigRepository.GetAllAsync());
        }


        [HttpPost]
        public async Task<ActionResult<Categoria>> Adicionar(EmailConfig email)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (await _emailConfigRepository.PegarEmailPorPrioridade(email.Prioridade) != null)
            {
                NotificarErro("ja exite um email na prioridade" + email.Prioridade);
                return CustomResponse();
            }

            email.id = Guid.NewGuid();

            await _emailConfigRepository.AddAsync(email);

            return CustomResponse(email);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EmailConfig>> Atualizar(Guid id, EmailConfig email)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (!await _emailConfigRepository.ExisteId(id)) return NotFound();

            var prioridade = await _emailConfigRepository.PegarEmailPorPrioridade(email.Prioridade);
            if (prioridade != null && prioridade.id != id )
            {
                NotificarErro("ja exite um email na prioridade " + email.Prioridade);
                return CustomResponse();
            }

            email.id = id;

            await _emailConfigRepository.UpdateAsync(email);

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EmailConfig>> Excluir(Guid id)
        {
            if (!await _emailConfigRepository.ExisteId(id)) return NotFound();

            await _emailConfigRepository.DeleteAsync(id);

            return CustomResponse();
        }

        [HttpPost("teste")]
        public async Task<IActionResult> EnviarEmailTest(string nome, string email)
        {
            try
            {
                await _mailService.Test(email, nome);
                return CustomResponse();
            }
            catch (Exception)
            {
                NotificarErro("erro ao enviar email");
                return CustomResponse();
            }
            
        }
    }
}

using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/Admin/Email")]
    [ApiController]
    public class EmailAdminController : MainController
    {
        private readonly IEmailService _mailService;
        private readonly IEmailConfigRepository _emailConfigRepository;

        public EmailAdminController(IEmailService mailService,
                               IEmailConfigRepository emailConfigRepository)
        {
            _mailService = mailService;
            _emailConfigRepository = emailConfigRepository;
        }

        /*[HttpGet]
        public async Task<ActionResult<EmailConfig>> ObterEmails()
        {            
            return CustomResponse(await _emailConfigRepository.GetAllAsync());
        }


        [HttpPost]
        public async Task<ActionResult<Categoria>> Adicionar(EmailConfig email)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (await _emailConfigRepository.PegarEmailPorPrioridade(email.Prioridade) is not null)
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
            if (prioridade is not null && prioridade.id != id )
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
        }*/

        [HttpPost("teste")]
        public async Task<IActionResult> EnviarEmailTest(string nome, string email)
        {
            try
            {
                await _mailService.Test(email, nome);
                return CustomResponseAsync();
            }
            catch (Exception e)
            {
                AddError("erro ao enviar email, tente novamente mais tarde " + e);
                return CustomResponseAsync();
            }

        }
    }
}

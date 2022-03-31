using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Application.Pessoas.Commands;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.CrossCutting.Identity.ViewModels;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class PerfilController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator  _mediator;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IAspNetUser _user;

        private readonly UserManager<Usuario> _userManager;

        private readonly IEmailService _emailService;

        public PerfilController(IMapper mapper, IMediator mediator, IPessoaRepository pessoaRepository, IAspNetUser user, UserManager<Usuario> userManager, IEmailService emailService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _pessoaRepository = pessoaRepository;
            _user = user;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterDados()
        {
            var data = await (await _pessoaRepository.GetAllAsync())
            .ProjectTo<PessoaUpdateViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.id_usuario == _user.ObterUserId());

            return data is null ? NotFound() : CustomResponseAsync(data);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarDados(AtualizarPessoaCommand atualizarPessoaCommand)
        {
            atualizarPessoaCommand.UsuarioId = _user.ObterUserId();
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _mediator.Send(atualizarPessoaCommand));
        }

        /// <summary>
        /// Requisição usada para mudar a senha de um usuário que esta logado
        /// </summary>
        /// <param name="mudarSenha">É necessário enviar a senha atual e a nova senha</param>
        /// <returns></returns>
        [HttpPost("MudarSenha")]
        public async Task<ActionResult> MudarSenha(MudarSenhaViewModel mudarSenha)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);
            var user = await _userManager.FindByIdAsync(_user.ObterUserId().ToString());
            var result = await _userManager.ChangePasswordAsync(user, mudarSenha.SenhaAtual, mudarSenha.NovaSenha);

            if (result.Succeeded)
            {
                await _emailService.SendEmailAsync(user.Email, "Sua senha foi alterada", "proteja sua conta");
                return CustomResponseAsync();
            }
            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponseAsync();

        }
    }
}

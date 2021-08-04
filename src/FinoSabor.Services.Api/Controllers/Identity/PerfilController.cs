using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.CrossCutting.Identity.ViewModels;
using FinoSabor.Services.Api.Controllers.Base;
using System.Threading.Tasks;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Domain.Entities;
using AutoMapper;
using FinoSabor.Domain.ViewModels.Pessoa;

namespace FinoSabor.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class PerfilController : MainController
    {

        private readonly IPerfilService _perfilService;
        private readonly IMapper _mapper;

        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger _logger;

        private readonly IEmailService _emailService;

        public PerfilController(INotificador notificador, IAspNetUser user,
                              IPerfilService perfilService,
                              SignInManager<Usuario> signInManager,
                              IEmailService emailService,
                              IMapper mapper,
                              UserManager<Usuario> userManager, ILogger<AutenticaçãoController> logger) : base(notificador, user)
        {
            _perfilService = perfilService;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> ObterDados()
        {
            var data = await _perfilService.ObterDados(AppUser.ObterUserId());

            return data is null ? NotFound() : CustomResponse(data);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarDados(PessoaUpdateViewModel pessoa)
        {
            pessoa.id_usuario = AppUser.ObterUserId();
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _perfilService.Atualizar(_mapper.Map<Pessoa>(pessoa)));

        }


        /// <summary>
        /// Requisição usada para mudar a senha de um usuário que esta logado
        /// </summary>
        /// <param name="mudarSenha">É necessário enviar a senha atual e a nova senha</param>
        /// <returns></returns>
        [HttpPost("MudarSenha")]
        public async Task<ActionResult> MudarSenha(MudarSenhaViewModel mudarSenha)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = await _userManager.FindByIdAsync(AppUser.ObterUserId().ToString());
            var result = await _userManager.ChangePasswordAsync(user, mudarSenha.SenhaAtual, mudarSenha.NovaSenha);

            if (result.Succeeded)
            {
                await _emailService.SendEmailAsync(user.Email, "Sua senha foi alterada", "proteja sua conta");
                return CustomResponse();
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse();

        }

       /* [HttpPost("MudarSenha")]
        public async Task<ActionResult> MudarSenha(MudarSenhaViewModel mudarSenha)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = await _userManager.FindByIdAsync(AppUser.ObterUserId().ToString());
            var result = await _userManager.ChangePasswordAsync(user, mudarSenha.SenhaAtual, mudarSenha.NovaSenha);

            if (result.Succeeded)
            {
                await _emailService.SendEmailAsync(user.Email, "Sua senha foi alterada", "proteja sua conta");
                return CustomResponse();
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse();

        }*/

    }
}

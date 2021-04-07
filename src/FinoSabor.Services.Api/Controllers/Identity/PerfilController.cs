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

namespace FinoSabor.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class PerfilController : MainController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger _logger;

        private readonly IEmailService _emailService;

        public PerfilController(INotificador notificador, IAspNetUser user,
                              SignInManager<Usuario> signInManager,
                              IEmailService emailService,
                              UserManager<Usuario> userManager, ILogger<AutenticacaoController> logger) : base(notificador, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _logger = logger;
        }


        /// <summary>
        /// Requisição usada para mudar a senha de um usuário que esta logado
        /// </summary>
        /// <param name="changePassword">É necessário enviar a senha atual e a nova senha</param>
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

    }
}

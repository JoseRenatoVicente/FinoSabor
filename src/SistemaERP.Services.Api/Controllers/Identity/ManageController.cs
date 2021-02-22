using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Infra.CrossCutting.Identity.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.CrossCutting.Identity.ViewModels;
using SistemaERP.Services.Api.Controllers.Base;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class ManageController : MainController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger _logger;

        private readonly IEmailService _emailService;

        public ManageController(INotificador notificador, IAspNetUser user,
                              SignInManager<Usuario> signInManager,
                              IEmailService emailService,
                              UserManager<Usuario> userManager, ILogger<AuthController> logger) : base(notificador, user)
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
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassoword(ChangePasswordViewModel changePassword)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = await _userManager.FindByIdAsync(AppUser.ObterUserId().ToString());
            var result = await _userManager.ChangePasswordAsync(user, changePassword.Currentpassword, changePassword.Newpassword);

            if (result.Succeeded)
            {
                //await _emailService.SendAsync(user.Email, "Sua senha foi alterada", "proteja sua conta");
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

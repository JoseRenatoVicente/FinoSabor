using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Infra.CrossCutting.Identity.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.CrossCutting.Identity.ViewModels;
using SistemaERP.Infra.Data.Repository.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class AccountController : MainController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger _logger;
        private readonly ITemplatesEmailRepository _templatesEmailRepository;

        private readonly IEmailService _emailService;

        public AccountController(INotificador notificador, IAspNetUser user,
                              SignInManager<Usuario> signInManager,
                              ITemplatesEmailRepository templatesEmailRepository,
                              IEmailService emailService,
        UserManager<Usuario> userManager, ILogger<AuthController> logger) : base(notificador, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _templatesEmailRepository = templatesEmailRepository;
            _logger = logger;
            _emailService = emailService;
        }



        /// <summary>
        /// Requisição usada para recuperação da conta
        /// </summary>
        /// <param name="forgotPassword">É necessário enviar o email da conta</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Não revelar se o usuario nao existe ou nao esta confirmado
                NotificarErro("O Usuário já tem um email enviado para confirmação");
                return CustomResponse();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = "localhost:5001/ResetPassword?userId=" + user.Id + "?token="+ code ;
            await _emailService.SendEmailAsync(user.Email, "Esqueci minha senha", "Por favor altere sua senha clicando aqui: " + callbackUrl);
            //await _emailSender.SendEmailAsync(message);
            return Ok();


        }

        /// <summary>
        /// Requisição usada para trocar a senha após receber um link de reset de senha
        /// </summary>
        /// <param name="resetPassword">É necessário enviar o userId, code e uma nova senha</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = await _userManager.FindByIdAsync(resetPassword.UserId);
            if (user == null)
            {
                // Não revelar se o usuario nao existe ou nao esta confirmado
                return BadRequest();
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse();

        }



        /// <summary>
        /// Requisição usada para confirmar o email
        /// </summary>
        /// <param name="userId">É necessário enviar o userId e code </param>
        /// <param name="code">É necessário enviar o userId e code </param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmail([Required] string userId, [Required] string code)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var result = await _userManager.ConfirmEmailAsync(new Usuario { Id = userId }, code);
            return CustomResponse(result.Succeeded ? "Email Confirmado" : "Erro");
        }

        



    }
}

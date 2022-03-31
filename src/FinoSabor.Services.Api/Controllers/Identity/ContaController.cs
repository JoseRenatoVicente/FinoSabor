using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.ViewModels;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class ContaController : MainController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger _logger;

        private readonly IEmailService _emailService;

        public ContaController(SignInManager<Usuario> signInManager,
                              IEmailService emailService,
        UserManager<Usuario> userManager, ILogger<AutenticacaoController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailService = emailService;
        }



        /// <summary>
        /// Requisição usada para recuperação da conta
        /// </summary>
        /// <param name="email">É necessário enviar o email da conta</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("EsqueceuSenha")]
        public async Task<ActionResult> EsqueceuSenha(string email)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                // Não revelar se o usuario nao existe ou nao esta confirmado
                AddError("O Usuário já tem um email enviado para confirmação");
                return CustomResponseAsync();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = "https://www.finosabor.me/conta/reset-senha?userId=" + user.Id + "&token=" + code;

            await _emailService.SendEmailAsync(user.Email, "Esqueci minha senha", "Por favor altere sua senha clicando aqui: " + callbackUrl);
            return Ok();


        }

        /// <summary>
        /// Requisição usada para trocar a senha após receber um link de reset de senha
        /// </summary>
        /// <param name="resetPassword">É necessário enviar o userId, code e uma nova senha</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ResetSenha")]
        public async Task<ActionResult> ResetSenha(ResetPasswordViewModel resetPassword)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);

            var user = await _userManager.FindByIdAsync(resetPassword.UserId);
            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token.Replace(" ", "+"), resetPassword.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponseAsync();

        }



        /// <summary>
        /// Requisição usada para confirmar o email
        /// </summary>
        /// <param name="userId">É necessário enviar o userId e code </param>
        /// <param name="code">É necessário enviar o userId e code </param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ConfirmarEmail")]
        public async Task<ActionResult> ConfirmarEmail([Required] Guid userId, [Required] string code)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);

            var result = await _userManager.ConfirmEmailAsync(new Usuario { Id = userId }, code);

            if (!result.Succeeded) AddError("Link expirado");

            return CustomResponseAsync();
        }





    }
}

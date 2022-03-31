using FinoSabor.Application.Services;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.ViewModels;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Identity
{

    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}")]
    [Route("api")]
    public class AutenticacaoController : MainController
    {
        private readonly AuthenticationService _authenticationService;

        public AutenticacaoController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);

            var user = new Usuario
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                var usertoRole = await _authenticationService.UserManager.FindByNameAsync(usuarioRegistro.Email);
                await _authenticationService.UserManager.AddToRoleAsync(usertoRole, "usuario");

                await _authenticationService._pessoaRepository.AddAsync(new Pessoa { UsuarioId = usertoRole.Id, Nome = usuarioRegistro.Nome, DataCadastro = DateTime.Now });
                //TODO: arrumar

                await _authenticationService.SignInManager.SignInAsync(user, false);
                return CustomResponseAsync(await _authenticationService.GerarJwt(usuarioRegistro.Email));
            }

            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponseAsync();
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);

            var result = await _authenticationService.SignInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded)
            {
                return CustomResponseAsync(await _authenticationService.GerarJwt(usuarioLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AddError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponseAsync();
            }

            AddError("Usuário ou Senha incorretos");
            return CustomResponseAsync();
        }
        [HttpPost("Checar-Login")]
        public ActionResult CheckLogin()
        {
            return Ok();
        }



        /*[HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                NotificarErro("Refresh Token inválido");
                return CustomResponse();
            }

            var token = await _authenticationService.ObterRefreshToken(Guid.Parse(refreshToken));

            if (token is null)
            {
                NotificarErro("Refresh Token expirado");
                return CustomResponse();
            }

            return CustomResponse(await _authenticationService.GerarJwt(token.Username));
        }*/

    }
}

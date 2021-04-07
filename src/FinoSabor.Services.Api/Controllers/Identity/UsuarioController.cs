using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Identity
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {

        private readonly UserManager<Usuario> _userManager;
        public UsuarioController(INotificador notificador, IAspNetUser appUser,
                                 UserManager<Usuario> userManager) : base(notificador, appUser)
        {
            _userManager = userManager;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return NotFound();

                var userViewModel = new UsuarioViewModel
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    DataCadastro = user.DataCadastro,
                    Email = user.Email,
                    LockoutEnabled = user.LockoutEnabled
                };

            return userViewModel;
        }



    }
}

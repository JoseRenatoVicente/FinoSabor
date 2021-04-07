using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Infra.CrossCutting.Identity.Extensions;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using FinoSabor.Application.ViewModels;
using System.Threading.Tasks;
using AutoMapper;
using FinoSabor.Domain.Entities.Identity;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Admin/Funcao")]
    public class FuncaoAdminController : MainController
    {
        public readonly SignInManager<Usuario> SignInManager;
        public readonly UserManager<Usuario> UserManager;
        public readonly RoleManager<Funcao> _roleManager;
        private readonly AppSettings _appSettings;
        private readonly AppTokenSettings _appTokenSettingsSettings;
        private readonly IMapper _mapper;

        private readonly IAspNetUser _aspNetUser;

        public FuncaoAdminController(INotificador notificador, IAspNetUser user,
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            RoleManager<Funcao> roleManager,
            IOptions<AppSettings> appSettings,
            IMapper mapper,
            IOptions<AppTokenSettings> appTokenSettingsSettings,
            IAspNetUser aspNetUser) : base(notificador, user)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
            _appTokenSettingsSettings = appTokenSettingsSettings.Value;
            _aspNetUser = aspNetUser;
            _mapper = mapper;
        }


        [HttpGet("UsuariosAdmin")]
        public async Task<List<UsuarioViewModel>> UsuariosAdmin()
        {
            var model = new List<UsuarioViewModel>();

            var listaUsuarios = await UserManager.GetUsersInRoleAsync("admin");
            foreach (var user in listaUsuarios)
            {
                var userViewModel = new UsuarioViewModel
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    DataCadastro = user.DataCadastro,
                    Email = user.Email,
                    LockoutEnabled = user.LockoutEnabled 
                };

                model.Add(userViewModel);
            }

            return model;
        }

        [HttpGet("UsuariosComuns")]
        public async Task<List<UsuarioViewModel>> UsuariosComuns()
        {

            var model = new List<UsuarioViewModel>();

            var listaUsuarios = await UserManager.GetUsersInRoleAsync("usuario");
            foreach (var user in listaUsuarios)
            {
                var userViewModel = new UsuarioViewModel
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    DataCadastro = user.DataCadastro,
                    Email = user.Email,
                    LockoutEnabled = user.LockoutEnabled
                };

                model.Add(userViewModel);
            }

            return model;
        }

        [HttpPost("AdicionarFuncaoAdmin")]
        public async Task<ActionResult> AdicionarFuncaoUsuario(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);

            await UserManager.RemoveFromRoleAsync(user, "usuario");

            await UserManager.AddToRoleAsync(user, "admin");

            return CustomResponse();
        }


        [HttpDelete("RemoverFuncaoAdmin")]
        public async Task<ActionResult> ExcluirFuncaoAdminUsuario(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);

            await UserManager.RemoveFromRoleAsync(user, "admin");

            await UserManager.AddToRoleAsync(user, "usuario");

            return CustomResponse();
        }
    }
}

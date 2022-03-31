using AutoMapper;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.Extensions;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Admin/Funcao")]
    public class FuncaoAdminController : MainController
    {
        private readonly SignInManager<Usuario> SignInManager;
        private readonly UserManager<Usuario> UserManager;
        private readonly RoleManager<Funcao> _roleManager;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;


        public FuncaoAdminController(
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            RoleManager<Funcao> roleManager,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }




        [HttpPost("AdicionarFuncaoAdmin")]
        public async Task<ActionResult> AdicionarFuncaoUsuario(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);

            await UserManager.RemoveFromRoleAsync(user, "usuario");

            await UserManager.AddToRoleAsync(user, "admin");

            return CustomResponseAsync();
        }


        [HttpDelete("RemoverFuncaoAdmin")]
        public async Task<ActionResult> ExcluirFuncaoAdminUsuario(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);

            await UserManager.RemoveFromRoleAsync(user, "admin");

            await UserManager.AddToRoleAsync(user, "usuario");

            return CustomResponseAsync();
        }
    }
}
